using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tarea3RegPrestamo.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Tarea3RegPrestamo.Models;

namespace Tarea3RegPrestamo.BLL.Tests
{
    [TestClass()]
    public class PersonaBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Persona persona = new Persona();
            persona.PersonaId = 3;
            persona.Normbre = "Steven";
            persona.Telofono = "829-411";
            persona.Cedula = "444";
            persona.Direccion = "C MAX";
            persona.Balance = Convert.ToDecimal(400.00);
            paso = PersonaBLL.Guardar(persona);
            Assert.AreEqual(paso, true);
        
    }
    }
}