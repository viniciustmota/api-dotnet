using Api.Domain.Dtos;
using Api.Domain.Dtos.Metadata;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Municipio
{
    public interface IMunicipioService : IBaseAppService<
        MunicipioEntity,
        MunicipioDto,
        MunicipioDtoCreate,
        MunicipioDtoUpdate,
        Guid,
        MunicipioDtoCompleto,
        object>
    {
        Task<MunicipioDtoCompleto?> GetCompleteByIBGE(int codigoIBGE);
    }
}