using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IUserRepository : IRepository<UserEntity, Guid>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}