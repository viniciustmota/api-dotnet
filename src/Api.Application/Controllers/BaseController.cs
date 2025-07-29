using Api.Domain.Dtos;
using Api.Domain.Dtos.Metadata;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<
        TService,
        TEntity,
        TDto,
        TDtoCreate,
        TDtoUpdate,
        TId,
        TDtoCompleto,
        TModel> : ControllerBase
        where TService : IBaseAppService<TEntity, TDto, TDtoCreate, TDtoUpdate, TId, TDtoCompleto, TModel>
    {
        protected readonly TService _service;

        public BaseController(TService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(TId id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.Get(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("complete/{id}")]
        public virtual async Task<IActionResult> GetCompleteById(TId id)
        {
            var result = await _service.GetCompleteById(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("metadata")]
        public virtual async Task<IActionResult> GetMetadata()
        {
            var metadata = await _service.GetMetadata();
            return Ok(metadata);
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20,
            [FromQuery] string? search = null,
            [FromQuery] string? order = null,
            [FromQuery] string? direction = null,
            [FromQuery] string? filter = null)
        {
            var result = await _service.GetAll(page, pageSize, search, order, direction, filter);
            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TDtoCreate dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.Post(dto);
            if (result == null)
                return BadRequest();

            return CreatedAtAction(nameof(Get), new { id = ((dynamic)result).Id }, result);
        }

        [HttpPut()]
        public virtual async Task<IActionResult> Put([FromBody] TDtoUpdate dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.Put(dto);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(TId id)
        {
            var result = await _service.Delete(id);
            return Ok(result);
        }

        [HttpDelete]
        public virtual async Task<IActionResult> DeleteBatch([FromBody] List<DeleteDto> items)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ids = items.Select(v => v.Id).ToList();

            var deleted = await _service.DeleteBatch(ids);
            return Ok(new { deletedCount = deleted });
        }
    }
}
