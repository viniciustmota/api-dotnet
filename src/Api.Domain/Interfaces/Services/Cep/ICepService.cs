using Api.Domain.Dtos.Cep;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Cep
{
    public interface ICepService : IBaseAppService<
        CepEntity,
        CepDto,
        CepDtoCreate,
        CepDtoUpdate,
        Guid,
        CepDto,
        object>
    {
        Task<CepDto> GetByCep(string cep);
        Task<CepDtoVisualizacao> GetVisualizacao(string cep);
    }
}
