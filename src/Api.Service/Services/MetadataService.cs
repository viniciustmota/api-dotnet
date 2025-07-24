using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json.Serialization;
using Api.Domain.Dtos.Field;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Field;
using Api.Domain.Interfaces.Services.Municipio;
using Api.Domain.Interfaces.Services.Uf;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Service.Services
{
    public class MetadataResponse
    {
        public List<FieldDto> Metadata { get; set; }
    }

    public class MetadataService : IMetadataService
    {
        public MetadataService()
        {
        }

        public async Task<List<FieldDto>> GenerateMetadata<T>(IServiceProvider serviceProvider)
        {
            var type = typeof(T);
            var fields = new List<FieldDto>();

            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var visibleAttr = prop.GetCustomAttribute<VisibleAttribute>();
                var keyAttr = prop.GetCustomAttribute<KeyAttribute>();
                var jsonAttr = prop.GetCustomAttribute<JsonPropertyNameAttribute>();
                var displayAttr = prop.GetCustomAttribute<DisplayAttribute>();
                var requiredAttr = prop.GetCustomAttribute<RequiredAttribute>();
                var optionsAttr = prop.GetCustomAttribute<OptionsAttribute>();

                var field = new FieldDto
                {
                    Property = jsonAttr.Name,
                    Label = displayAttr?.Name ?? prop.Name,
                    Type = MapType(prop.PropertyType, prop),
                    Required = requiredAttr != null,
                    Key = keyAttr != null,
                    Visible = visibleAttr != null ? visibleAttr.Visible : false,
                    Editable = true
                };

                if (optionsAttr != null && !string.IsNullOrEmpty(optionsAttr.Source))
                {
                    switch (optionsAttr.Source.ToLower())
                    {
                        case "ufs":
                            var ufService = serviceProvider.GetService<IUfService>();
                            var ufs = (await ufService.GetAll())
                                .OrderBy(u => u.Sigla)
                                .Select(uf => new OptionDto
                                {
                                    Label = uf.Sigla,
                                    Value = uf.Id
                                }).ToList();

                            field.Options = ufs;
                            break;
                            
                        case "municipios":
                            var municipioService = serviceProvider.GetService<IMunicipioService>();
                            if (municipioService == null)
                                throw new InvalidOperationException("IMunicipioService não registrado no DI.");

                            var result = await municipioService.GetAll(
                                1,                  
                                int.MaxValue
                            );
                            var municipios = result.Items
                                .OrderBy(m => m.Nome)
                                .Select(m => new OptionDto
                                {
                                    Label = m.Nome,
                                    Value = m.Id,
                                })
                                .ToList();

                            field.Options = municipios;
                            break;
                    }
                }

                fields.Add(field);
            }
            return fields;
        }

        private static string MapType(Type type, PropertyInfo prop)
        {
            if (prop.GetCustomAttribute<ComboAttribute>() != null)
                return "combo";

            if (type.IsEnum)
                return "combo";

            if (type == typeof(string) || type == typeof(Guid)) return "string";
            if (type == typeof(int) || type == typeof(long)) return "number";
            if (type == typeof(bool)) return "boolean";
            if (type == typeof(DateTime)) return "date";
            return "object";
        }
    }
}