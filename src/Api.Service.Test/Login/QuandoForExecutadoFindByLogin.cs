using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Bogus;
using Moq;

namespace Api.Service.Test.Login
{
    public class QuandoForExecutadoFindByLogin
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;
        private Faker _faker;

        public QuandoForExecutadoFindByLogin()
        {
            _faker = new Faker("pt_BR");
        }

        [Fact(DisplayName = "É Possivel executar o Método FindByLogin.")]
        public async Task E_Possivel_Executar_Metodo_FindByLogin()
        {
            var email = _faker.Internet.Email();
            var objetoRetorno = new LoginResultDto
            {
                authenticated = true,
                created = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = DateTime.UtcNow.AddHours(8).ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = Guid.NewGuid().ToString(),
                message = "Usuário logado com sucesso",
                name = _faker.Name.FullName(),
                userName = email
            };

            var loginDto = new LoginDto
            {
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objetoRetorno);
            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(loginDto);
            Assert.NotNull(result);



        }
    }
}