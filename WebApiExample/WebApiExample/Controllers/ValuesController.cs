using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //rajapinta
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "valueA", "valueB" };
        }

        // GET api/values/5 HAKU
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value AB";
        }

        // POST api/values LISÄYS
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5 PÄIVITYS
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5 POISTO
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
