using Api.Domain.Dtos;
using Api.Domain.Dtos.Metadata;

namespace Api.Domain.Interfaces.Services
{
    public interface IBaseAppService<TEntity, TDto, TDtoCreate, TDtoUpdate, TId, TDtoCompleto, TModel>
    {
        Task<TDto> Get(TId id);
        Task<TDtoCompleto> GetCompleteById(TId id);
        Task<PagedResultDto<TDto>> GetAll(
                    int page,
                    int pageSize,
                    string? search = null,
                    string? order = null,
                    string? direction = null,
                    string? filter = null);
        Task<MetadataDto> GetMetadata();
        Task<TDto> Post(TDtoCreate dtoCreate);
        Task<TDto> Put(TDtoUpdate dtoUpdate);
        Task<bool> Delete(TId id);
        Task<int> DeleteBatch(List<TId> ids);     
    }
}