using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Service.User;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Usuario.QuandoRequisitarGetAll
{
    public class Retorno_BadRequest
    {

            private UsersController _controller;
            private Faker _faker;
            public Retorno_BadRequest()
            {
                _faker = new Faker("pt_BR");
            }
        [Fact(DisplayName = "É possível Realizar o Get All.")]
        public async Task E_Possivel_Invocar_a_Controller_GetAll()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync
            (
                new List<UserDto>
                {
                    new UserDto
                    {
                    Id = Guid.NewGuid(),
                    Name = _faker.Name.FullName(),
                    Email = _faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow
                    },
                    new UserDto
                    {
                    Id = Guid.NewGuid(),
                    Name = _faker.Name.FullName(),
                    Email = _faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow
                    }
                }
            );
            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");
            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}