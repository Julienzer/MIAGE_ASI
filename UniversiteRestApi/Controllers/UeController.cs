using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UniversiteRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UeController : ControllerBase
    {
        // GET: api/<UeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
