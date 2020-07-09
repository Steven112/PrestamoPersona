using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tarea3RegPrestamo.BLL;
using Tarea3RegPrestamo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        //GET: api/Prestamos
        [HttpGet]
        public ActionResult<IEnumerable<Prestamos>> Get()
        {
            return PrestamosBLL.GetEstudiante();
        }
        // GET api/<PrestamoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PrestamoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PrestamoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PrestamoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
