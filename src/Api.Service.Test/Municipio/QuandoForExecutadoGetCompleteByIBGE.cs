using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoGetCompleteByIBGE : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possível executar o Método GETCompleteByIBGE.")]
        public async Task E_Possivel_Executar_Metodo_Get_Complete_by_IBGE()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.GetCompleteByIBGE(CodigoIBGEMunicipio))
                        .ReturnsAsync(municipioDtoCompleto);
            _service = _serviceMock.Object;

            var result = await _service.GetCompleteByIBGE(CodigoIBGEMunicipio);
            Assert.NotNull(result);
            Assert.True(result.Id == IdMunicipio);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIBGEMunicipio, result.CodIBGE);
            Assert.NotNull(result.Uf);
        }
    }
}