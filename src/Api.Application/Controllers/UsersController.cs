using System.Net;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Service.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController<
        IUserService,
        UserEntity,
        UserDto,
        UserDtoCreate,
        UserDtoUpdate,
        Guid,
        UserDto,
        object>
    {
        public UsersController(IUserService service) : base(service)
        {
        }
    }
}
