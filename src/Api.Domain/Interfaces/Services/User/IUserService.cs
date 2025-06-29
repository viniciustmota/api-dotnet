using Api.Domain.Dtos.User;

namespace Api.Domain.Interfaces.Service.User
{
    public interface IUserService
    {
        Task<UserDto> Get(Guid id);
        Task<IEnumerable<UserDto>> GetAll();

        Task<UserDtoCreateResult> Post(UserDtoCreate user);
        Task<UserDtoUpdateResult> Put(UserDtoUpdate user);
        Task<bool> Delete(Guid id);
    }
}
