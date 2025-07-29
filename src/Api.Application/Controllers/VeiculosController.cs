using Api.Domain.Dtos.User;
using Api.Domain.Dtos.Veiculo;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Service.User;
using Api.Domain.Interfaces.Services.Veiculo;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : BaseController<
        IVeiculoService,
        VeiculoEntity,
        VeiculoDto,
        VeiculoDtoCreate,
        VeiculoDtoUpdate,
        Guid,
        VeiculoDto,
        object>
    {
        public  VeiculosController(IVeiculoService service) : base(service)
        {
        }
    }
}
