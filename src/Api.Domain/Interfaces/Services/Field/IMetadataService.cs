using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Field;

namespace Api.Domain.Interfaces.Services.Field
{
    public interface IMetadataService
    {
        Task<List<FieldDto>> GenerateMetadata<T>(IServiceProvider serviceProvider);
    }
}