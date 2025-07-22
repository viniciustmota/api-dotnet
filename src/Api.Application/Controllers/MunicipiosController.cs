using System.Net;
using Api.Domain.Dtos.Common;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class MunicipiosController : ControllerBase
    {
        public IMunicipioService _service { get; set; }
        public MunicipiosController(IMunicipioService service)
        {
            _service = service;
        }

        [HttpGet("metadata")]
        public async Task<IActionResult> GetMetadata()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetMetadata());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] string? search)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetAll(search));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetMunicipioWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Get(id);
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
        [HttpGet]
        [Route("Complete/{id}")]
        public async Task<ActionResult> GetCompleteById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.GetCompleteById(id);
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
        [HttpGet]
        [Route("byIBGE/{codigoIBGE}")]
        public async Task<ActionResult> GetCompleteByIBGE(int codigoIBGE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.GetCompleteByIBGE(codigoIBGE);
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
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MunicipioDtoCreate dtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Post(dtoCreate);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetMunicipioWithId", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] MunicipioDtoUpdate dtoUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(dtoUpdate);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 bad request - solicitação inválida
            }
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete]
        public async Task<ActionResult> DeleteBatch([FromBody] List<IdWrapperDto> items)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 bad request
            }

            if (items == null || !items.Any())
            {
                return BadRequest("Lista de IDs vazia.");
            }

            // DEBUG: imprime os GUIDs recebidos
            Console.WriteLine("Recebidos para exclusão em lote:");
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.Id}");
            }


            try
            {
                // Extrai só os GUIDs dos objetos recebidos
                var ids = items.Select(x => x.Id).ToList();

                var result = await _service.DeleteBatch(ids);
                return Ok(new { deletedCount = result });
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}

//  Para a ação removeAll, será feito uma requisição de exclusão em lote para esse mesmo endpoint passando, uma lista
//    * de objetos com os campos setados como key: true via payload.
//    *
//    * > DELETE {end-point}
//    *
//    * > Payload: [ {key}, {key} ... {key} ]
//    *
//    * 

// *  <po-page-dynamic-table
//    *    [p-actions]="{ removeAll: true }"
//    *    [p-fields]="[ { property: 'id', key: true } ]"
//    *    p-service="/api/po-samples/v1/people"
//    *    ...>
//    *  </po-page-dynamic-table>
//    *


//    *
//    * Resquisição disparada, onde foram selecionados 3 itens para serem removidos:
//    *
//    * 

// *  DELETE /api/po-samples/v1/people HTTP/1.1
//    *  Host: localhost:4000
//    *  Connection: keep-alive
//    *  Accept: application/json, text/plain
//    *  ...
//    *


//    *
//    * Request payload:
//    *
//    * 

// * [{"id":2},{"id":4},{"id":5}]
//    *


//    *
//    * > Caso esteja usando metadados com o template, será disparado uma requisição na inicialização do template para buscar
//    * > os metadados da página passando o tipo do metadado esperado e a versão cacheada pelo browser.
//    * >
//    * > GET {end-point}/metadata?type=list&version={version}
//    */