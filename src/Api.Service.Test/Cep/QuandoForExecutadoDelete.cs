using Api.Domain.Interfaces.Services.Cep;
using Moq;

namespace Api.Service.Test.Cep
{
    public class QuandoForExecutadoDelete : CepTestes
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É Possível executar o Método Delete.")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Delete(IdCep))
                        .ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(IdCep);
            Assert.True(deletado);

            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);
        }
    }
}