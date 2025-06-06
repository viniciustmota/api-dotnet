using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value 5";
        }

        // POST: api/values
        [HttpPost]
        public void Post([FromBody] string value) { }

        // PUT: api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE: api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Logic to delete the value with the specified id
        }
        // PATCH: api/values/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody] string value)
        {
            // Logic to update the value with the specified id
        }

        // OPTIONS: api/values
        [HttpOptions]
        public IActionResult Options()
        {
            return Ok(new { message = "This is an OPTIONS response" });
        }

        // HEAD: api/values
        [HttpHead]
        public IActionResult Head()
        {
            return Ok();
        }
    }
}
