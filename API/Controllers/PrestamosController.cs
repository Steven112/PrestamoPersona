using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tarea3RegPrestamo.BLL;
using Tarea3RegPrestamo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        // GET: api/<PrestamosController>
        [HttpGet]
        public ActionResult<List<Prestamos>> Get()
        {
            return PrestamosBLL.GetPrestamos();
        }

        // GET api/<PrestamosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PrestamosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PrestamosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PrestamosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
