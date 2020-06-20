using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tarea3RegPrestamo.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using Tarea3RegPrestamo.Models;

namespace Tarea3RegPrestamo.BLL.Tests
{
    [TestClass()]
    public class MoraBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            MoraDetalle moraDetalle= new MoraDetalle(1,1,1, Convert.ToDecimal(100.00));
            List<MoraDetalle> list = new List<MoraDetalle>();
            list.Add(moraDetalle);
            Mora mora = new Mora();
            mora.MoraId = 3;
            mora.Fecha = DateTime.Now;
            mora.Total = Convert.ToDecimal(100.00);
            paso = MoraBLL.Guardar(mora);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            MoraDetalle moraDetalle = new MoraDetalle(1, 1, 1, Convert.ToDecimal(100.00));
            List<MoraDetalle> list = new List<MoraDetalle>();
            list.Add(moraDetalle);
            Mora mora = new Mora();
            mora.MoraId = 3;
            mora.Fecha = DateTime.Now;
            mora.Total = Convert.ToDecimal(130.00);
            paso = MoraBLL.Modificar(mora);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            var paso = MoraBLL.Eliminar(3);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = MoraBLL.Buscar(3);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Mora> lista = new List<Mora>();
            lista = MoraBLL.GetList(l => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var existe = MoraBLL.Existe(3);
            Assert.IsNotNull(existe);
        }

        [TestMethod()]
        public void GetMoraTest()
        {
            List<Mora> lista = new List<Mora>();
            lista = MoraBLL.GetMora();
            Assert.IsNotNull(lista);
        }
    }
}