using Api.Domain.Dtos;
using Api.Domain.Dtos.Metadata;
using Api.Domain.Dtos.Municipio;

namespace Api.Domain.Interfaces.Services.Municipio
{
    public interface IMunicipioService
    {
        Task<MunicipioDto> Get(Guid id);
        Task<MunicipioDtoCompleto> GetCompleteById(Guid id);
        Task<MunicipioDtoCompleto> GetCompleteByIBGE(int codIBGE);
        Task<PagedResultDto<MunicipioDto>> GetAll(
            int page,
            int pageSize,
            string? search = null,
            string? order = null,
            string? direction = null,
            string? filter = null);
        Task<MetadataDto> GetMetadata();
        Task<MunicipioDtoCreateResult> Post(MunicipioDtoCreate municipio);
        Task<MunicipioDtoUpdateResult> Put(MunicipioDtoUpdate municipio);
        Task<bool> Delete(Guid id);
        Task<int> DeleteBatch(List<Guid> ids);


    }
}