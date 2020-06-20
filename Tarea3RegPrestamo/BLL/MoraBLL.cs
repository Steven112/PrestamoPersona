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
    public class MoraBLL
    {
        public static bool Guardar(Mora mora)
        {
            if (!Existe(mora.MoraId))
                return Insertar(mora);
            else
                return Modificar(mora);
        }

        private static bool Insertar(Mora mora)
        {
            Prestamos prestamos = new Prestamos();
            bool paso = false;
            Contexto contexto = new Contexto();
            MoraDetalle moraDetalle = new MoraDetalle();
            try
            {
                contexto.moras.Add(mora);
                
                    
                
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
        public static bool Modificar(Mora mora)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM MoraDetalle Where MoraId = {mora.MoraId}");
                foreach (var item in mora.moradetalles)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                contexto.Entry(mora).State = EntityState.Modified;
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
            try
            {
                var envio = contexto.moras.Find(id);

                if (envio != null)
                {
                    contexto.moras.Remove(envio);
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

        public static Mora Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Mora mora;

            try
            {
                mora = contexto.moras.Where(e => e.MoraId == id).Include(e => e.moradetalles).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return mora;
        }

        public static List<Mora> GetList(Expression<Func<Mora, bool>> criterio)
        {
            List<Mora> lista = new List<Mora>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.moras.Where(criterio).ToList();
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
                encontrado = contexto.moras.Any(e => e.MoraId == id);
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

        public static List<Mora> GetMora()
        {
            List<Mora> lista = new List<Mora>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.moras.ToList();
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

