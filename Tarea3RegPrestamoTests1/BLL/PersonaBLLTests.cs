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

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Persona persona = new Persona();
            persona.PersonaId = 2;
            persona.Normbre = "Steven Cacers";
            persona.Telofono = "829-411";
            persona.Cedula = "444";
            persona.Direccion = "C MAX";
            persona.Balance = Convert.ToDecimal(400.00);
            paso = PersonaBLL.Modificar(persona);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            var paso = PersonaBLL.Eliminar(2);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = PersonaBLL.Buscar(2);
            Assert.IsNotNull(paso);
        }
    }
}