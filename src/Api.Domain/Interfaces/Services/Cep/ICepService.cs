using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Metadata;

namespace Api.Domain.Interfaces.Services.Cep
{
    public interface ICepService
    {
        Task<CepDto> Get(Guid id);
        Task<CepDto> Get(string cep);
        Task<MetadataDto> GetMetadata();
        Task<CepDtoVisualizacao> GetVisualizacao(string cep);
        Task<CepDtoCreateResult> Post(CepDtoCreate cep);
        Task<CepDtoUpdateResult> Put(CepDtoUpdate cep);
        Task<bool> Delete(Guid id);
    }
}