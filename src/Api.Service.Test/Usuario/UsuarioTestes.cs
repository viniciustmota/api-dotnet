using Api.Domain.Dtos.User;
using Bogus;

namespace Api.Service.Test.Usuario
{
    public class UsuarioTestes
    {
        public string NomeUsuario { get; private set; }
        public string EmailUsuario { get; private set; }
        public string NomeUsuarioAlterado { get; private set; }
        public string EmailUsuarioAlterado { get; private set; }
        public Guid IdUsuario { get; private set; }
        public List<UserDto> listaUserDto = new List<UserDto>();
        public UserDto userDto;
        public UserDtoCreate userDtoCreate;
        public UserDtoCreateResult userDtoCreateResult;
        public UserDtoUpdate userDtoUpdate;
        public UserDtoUpdateResult userDtoUpdateResult;
        private readonly Faker _faker;

        public UsuarioTestes()
        {
            _faker = new Faker("pt_BR");

            IdUsuario = Guid.NewGuid();
            NomeUsuario = _faker.Name.FullName();
            EmailUsuario = _faker.Internet.Email();
            NomeUsuarioAlterado = _faker.Name.FullName();
            EmailUsuarioAlterado = _faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = _faker.Name.FullName(),
                    Email = _faker.Internet.Email()
                };

                listaUserDto.Add(dto);
            }

            userDto = new UserDto
            {
                Id = IdUsuario,
                Name = NomeUsuario,
                Email = EmailUsuario
            };

            userDtoCreate = new UserDtoCreate
            {
                Name = NomeUsuario,
                Email = EmailUsuario
            };

            userDtoCreateResult = new UserDtoCreateResult
            {
                Id = IdUsuario,
                Name = NomeUsuario,
                Email = EmailUsuario,
                CreateAt = DateTime.UtcNow
            };

            userDtoUpdate = new UserDtoUpdate
            {
                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado
            };

            userDtoUpdateResult = new UserDtoUpdateResult
            {
                Id = IdUsuario,
                Name = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}