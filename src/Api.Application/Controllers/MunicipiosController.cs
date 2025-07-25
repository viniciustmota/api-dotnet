using System.Net;
using Api.Domain.Dtos.Common;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipiosController : BaseController<
        IMunicipioService,
        MunicipioEntity,
        MunicipioDto,
        MunicipioDtoCreate,
        MunicipioDtoUpdate,
        Guid,
        MunicipioDtoCompleto,
        object>
    {
        public MunicipiosController(IMunicipioService service) : base(service) { }
        
        [HttpGet("byIBGE/{codigoIBGE}")]
        public async Task<IActionResult> GetCompleteByIBGE(int codigoIBGE)
        {
            var result = await _service.GetCompleteByIBGE(codigoIBGE);
            if (result == null)
                return NotFound();

            return Ok(result);
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