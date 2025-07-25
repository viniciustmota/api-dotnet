using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Service.User;
using Api.Domain.Interfaces.Services.Field;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class UserService : BaseService<
        UserEntity,
        UserDto,
        UserDtoCreate,
        UserDtoUpdate,
        Guid,
        UserDto>,
        IUserService
    {
        public UserService(IRepository<UserEntity, Guid> repository, IMapper mapper, IMetadataService metadataService, IServiceProvider serviceProvider) : base(repository, mapper, metadataService, serviceProvider)
        {
        }
    }
}
