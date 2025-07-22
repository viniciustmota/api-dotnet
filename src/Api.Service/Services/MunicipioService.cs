using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Api.Data.Context;
using Api.Domain.Dtos;
using Api.Domain.Dtos.Field;
using Api.Domain.Dtos.Metadata;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Field;
using Api.Domain.Interfaces.Services.Municipio;
using Api.Domain.Interfaces.Services.Uf;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.Services
{
    public class MunicipioService : IMunicipioService
    {
        private readonly MyContext _context;
        private IMunicipioRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUfService _ufService;
        private readonly IMetadataService _metadataService;
        private readonly IServiceProvider _serviceProvider;

        public MunicipioService(IMunicipioRepository repository, IMapper mapper, IUfService ufService, MyContext context, IMetadataService metadataService, IServiceProvider serviceProvider)
        {
            _repository = repository;
            _mapper = mapper;
            _ufService = ufService;
            _context = context;
            _metadataService = metadataService;
            _serviceProvider = serviceProvider;
        }

        public async Task<MunicipioDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<MunicipioDto>(entity);
        }

        public async Task<MunicipioDtoCompleto> GetCompleteById(Guid id)
        {
            var entity = await _repository.GetCompleteById(id);
            return _mapper.Map<MunicipioDtoCompleto>(entity);
        }

        public async Task<MunicipioDtoCompleto> GetCompleteByIBGE(int codIBGE)
        {
            var entity = await _repository.GetCompleteByIBGE(codIBGE);
            return _mapper.Map<MunicipioDtoCompleto>(entity);
        }

        public async Task<PagedResultDto<MunicipioDto>> GetAll(int page = 1, int pageSize = 10, string? search = null)
        {
            var query = _repository.GetQueryable()
                .Include(m => m.Uf)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var normalized = search.ToLower();
                query = query.Where(m =>
                    m.Nome.ToLower().Contains(normalized) ||
                    m.CodIBGE.ToString().Contains(normalized) ||
                    m.Uf.Sigla.ToLower().Contains(normalized)
                    );
            }

            var total = await query.CountAsync();

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var dtos = _mapper.Map<IEnumerable<MunicipioDto>>(items);

            var ufs = await _ufService.GetAll();
            var ufDict = ufs.ToDictionary(uf => uf.Id, uf => uf.Sigla);

            foreach (var dto in dtos)
            {
                if (ufDict.TryGetValue(dto.UfId, out var sigla))
                {
                    dto.UfSigla = sigla;
                }
            }

            return new PagedResultDto<MunicipioDto>
            {
                Items = dtos,

            };
        }

        public async Task<PagedResultDto<MunicipioDto>> GetAll(string? search)
        {
            return await GetAll(1, int.MaxValue, search);
        }



        public async Task<MunicipioDtoCreateResult> Post(MunicipioDtoCreate municipio)
        {
            var model = _mapper.Map<MunicipioModel>(municipio);
            var entity = _mapper.Map<MunicipioEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<MunicipioDtoCreateResult>(result);
        }

        public async Task<MunicipioDtoUpdateResult> Put(MunicipioDtoUpdate municipio)
        {
            var model = _mapper.Map<MunicipioModel>(municipio);
            var entity = _mapper.Map<MunicipioEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<MunicipioDtoUpdateResult>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<int> DeleteBatch(List<Guid> ids)
        {
            var entities = await _context.Municipios
                .Where(m => ids.Contains(m.Id))
                .ToListAsync();

            _context.Municipios.RemoveRange(entities);
            return await _context.SaveChangesAsync();
        }

        public static List<FieldDto> preencherMetadata<T>()
        {
            var type = typeof(T);
            var fields = new List<FieldDto> {};
            var municipioDto = new MunicipioDto();

            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var displayAttr = prop.GetCustomAttribute<DisplayAttribute>();
                var requiredAttr = prop.GetCustomAttribute<RequiredAttribute>();

                fields.Add(new FieldDto
                {
                    Property = prop.Name,
                    Label = displayAttr?.Name ?? prop.Name,
                    Type = MapType(prop.PropertyType),
                    Required = requiredAttr != null
                });
            }

            return fields;
        }

        private static string MapType(Type type)
        {
            if (type == typeof(string)) return "string";
            if (type == typeof(int) || type == typeof(long)) return "number";
            if (type == typeof(bool)) return "boolean";
            if (type == typeof(DateTime)) return "date";
            return "object";
        }

        public async Task<MetadataDto> GetMetadata()
        {
           

            var metadata = new MetadataDto
            {
                Version = 1,
                Title = "Municípios",
                KeepFilters = false,
                Fields = await _metadataService.GenerateMetadata<MunicipioDto>(_serviceProvider)
            };

            return metadata;
        }
    }
}



// Criar uma função que gere isso

// Fields = new List<FieldDto> {
//     new FieldDto{ Property = "id", Label = "Id", Type = "string", Required = true, Visible = false, Key=true},
//     new FieldDto{ Property = "nome", Label = "Município", Type = "string", Required = true, Visible = true},
//     new FieldDto{ Property = "codIBGE", Label = "Código IBGE", Type = "number", Required = true, Visible = true },
//     new FieldDto{ Property = "ufId", Label = "UF", Type = "combo", Required = true, Options = ufs, Visible = true },
//     new FieldDto{ Property = "ufSigla", Label = "UF", Type = "string" , Required = false, Editable = false, Visible = true}
// }