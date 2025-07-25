using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Service.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : BaseController<
        IUserService,
        UserEntity,
        UserDto,
        UserDtoCreate,
        UserDtoUpdate,
        Guid,
        UserDto,
        object>
    {
        public  VeiculosController(IUserService service) : base(service)
        {
        }
    }
}
