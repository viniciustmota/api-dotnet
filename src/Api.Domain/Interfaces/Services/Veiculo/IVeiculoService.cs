using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Veiculo;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Veiculo
{
    public interface IVeiculoService : IBaseAppService<
        VeiculoEntity,
        VeiculoDto,
        VeiculoDtoCreate,
        VeiculoDtoUpdate,
        Guid,
        VeiculoDto,
        object>
    {}
}
