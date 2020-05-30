using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tarea3RegPrestamo.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Tarea3RegPrestamo.Models;

namespace Tarea3RegPrestamo.BLL.Tests
{
    [TestClass()]
    public class PrestamosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Prestamos Prestamo = new Prestamos(1, DateTime.Now, 3, "Compra terreno", Convert.ToDecimal(100.00), Convert.ToDecimal(100.00));
            paso = PrestamosBLL.Guardar(Prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Prestamos Prestamo = new Prestamos(1, DateTime.Now, 3, "Compra planta", Convert.ToDecimal(100.00), Convert.ToDecimal(100.00));
            paso = PrestamosBLL.Modificar(Prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {

            var paso = PrestamosBLL.Eliminar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {

            var paso = PrestamosBLL.Buscar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Prestamos> lista = new List<Prestamos>();
            lista = PrestamosBLL.GetList(l => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var existe = PrestamosBLL.Existe(1);
            Assert.IsNotNull(existe);
        }

        [TestMethod()]
        public void GetPrestamosTest()
        {
            List<Prestamos> lista = new List<Prestamos>();
            lista = PrestamosBLL.GetEstudiante();
            Assert.IsNotNull(lista);
        }
    }
}