using System.Net;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Api.Application.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto loginDto, [FromServices] ILoginService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (loginDto == null)
            {
                return BadRequest("Dados de login não informados.");
            }

            try
            {
                LoginResultDto result = await service.FindByLogin(loginDto);

                if (result == null)
                {
                    return Unauthorized(new
                    {
                        authenticated = false,
                        message = "Credenciais inválidas ou usuário não autorizado."
                    });
                }

                if (result.authenticated)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return Unauthorized(new
                        {
                            authenticated = false,
                            message = result.message ?? "Falha ao autenticar."
                        });
                    }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}