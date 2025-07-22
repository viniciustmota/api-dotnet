using Api.Domain.Dtos;

namespace Api.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<LoginResultDto> FindByLogin(LoginDto user);
    }
}