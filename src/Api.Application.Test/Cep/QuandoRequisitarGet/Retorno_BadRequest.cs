using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Cep.QuandoRequisitarGet
{
    public class Retorno_BadRequest
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possível Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new CepDto
                {
                    Id = Guid.NewGuid(),
                    Cep = "123456789",
                }
            );

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}