using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;

namespace Api.Domain.Interfaces.Service.User
{
    public interface IUserService: IBaseAppService<
        UserEntity,
        UserDto,
        UserDtoCreate,
        UserDtoUpdate,
        Guid,
        UserDto,
        object>
    {
    }
}
