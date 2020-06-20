using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tarea3RegPrestamo.DAL;
using Tarea3RegPrestamo.Models;

namespace Tarea3RegPrestamo.BLL
{
    public class PrestamosBLL
    {
        public static bool Guardar(Prestamos prestamos)
        {
            if (!Existe(prestamos.PrestamoId))
                return Insertar(prestamos);
            else
                return Modificar(prestamos);
        }
        private static bool Insertar(Prestamos prestamo)
        {
            Persona persona = new Persona();
            bool paso = false;
            Contexto contexto = new Contexto();
            Mora mora = new Mora();
            MoraDetalle moraDetalle = new MoraDetalle();
            try
            {

                if (contexto.prestamos.Add(prestamo) != null)
                {
                    contexto.personas.Find(prestamo.PersonaId).Balance += prestamo.Monto;
                    paso = contexto.SaveChanges() > 0;
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static bool Modificar(Prestamos prestamos)
        {
            bool paso = false;

            Contexto contexto = new Contexto();

            try
            {
                var persona = PersonaBLL.Buscar(prestamos.PersonaId);
                var anterior = Buscar(prestamos.PrestamoId);

                persona.Balance -= anterior.Monto;
                contexto.prestamos.Add(prestamos);

                persona.Balance += prestamos.Monto;
                PersonaBLL.Modificar(persona);

                prestamos.Balances = 1000;

                contexto.Entry(prestamos).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Prestamos prestamos = new Prestamos();
            try
            {
                var prestam = contexto.prestamos.Find(id);

                if (prestam != null)
                {
                    contexto.personas.Find(prestam.PersonaId).Balance -= prestam.Monto;
                    contexto.prestamos.Remove(prestam);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamos;

            try
            {
                prestamos = contexto.prestamos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return prestamos;
        }

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.prestamos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.prestamos.Any(e => e.PersonaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Prestamos> GetEstudiante()
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.prestamos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
