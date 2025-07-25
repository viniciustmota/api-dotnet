using System.Net;
using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Field;
using Api.Domain.Dtos.Metadata;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepsController : BaseController<
        ICepService,
        CepEntity,
        CepDto,
        CepDtoCreate,
        CepDtoUpdate,
        Guid,
        CepDto,
        object>
    {
        public CepsController(ICepService service) : base(service) {}

        [AllowAnonymous]
        [HttpGet]
        [Route("byCep/{cep}")]
        public async Task<ActionResult> Get(string cep)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.GetByCep(cep);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet("{cep}/visualizacao")]
        public async Task<IActionResult> GetVisualizacao(string cep)
        {
            var result = await _service.GetVisualizacao(cep);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}