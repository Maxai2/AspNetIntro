using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")] // Rest Full API
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var res = new JsonResult(new string[] { "value1", "value2" });

            return res;
        }

        // GET api/values/5 // SELECT
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return new JsonResult("value");
        }

        // POST api/values // INSERT
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5 // UPDATE
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
