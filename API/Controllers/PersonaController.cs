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
    public class PersonaController : ControllerBase
    {
        // GET: api/<PersonaController>
        [HttpGet]
        public ActionResult<List<Persona>> Get()
        {
            return PersonaBLL.GetPersona();
        }

        // GET api/<PersonaController>/5
        [HttpGet("{id}")]
        public ActionResult<List<Persona>> Get(int id)
        {
            return PersonaBLL.GetPersona();
        }

        // POST api/<PersonaController>
        [HttpPost]
        public void Post([FromBody] Persona persona)
        {
            PersonaBLL.Guardar(persona);
        }

       
        // DELETE api/<PersonaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PersonaBLL.Eliminar(id);
        }
    }
}
