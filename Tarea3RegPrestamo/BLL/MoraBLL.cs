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

                foreach(var item in mora.moradetalles)
                {
                    var prestamo = contexto.prestamos.Find(item.PrestamoId);
                    if (prestamo != null)
                    {
                        prestamo.Monto += item.Valor;
                        contexto.personas.Find(prestamo.PersonaId).Balance += item.Valor;
                    }
                    contexto.moras.Add(mora);
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
        public static bool Modificar(Mora mora)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            var anterior = Buscar(mora.MoraId);
            try
            {
                
                foreach (var item in anterior.moradetalles)
                {
                    var aux = contexto.prestamos.Find(item.PrestamoId);
                    if(!mora.moradetalles.Exists(d => d.MoraId == item.MoraId))
                    {
                        if (aux != null)
                        {
                            aux.Monto -= item.Valor;
                            contexto.personas.Find(aux.PersonaId).Balance -= item.Valor;
                        }

                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }
                foreach (var item in mora.moradetalles)
                {

                    var aux = contexto.prestamos.Find(item.PrestamoId);
                    if (item.MoraId==0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                        if (aux != null)
                        {
                            aux.Monto += item.Valor;
                            contexto.personas.Find(aux.PersonaId).Balance += item.Valor;
                        }

                    }
                    else
                    
                        contexto.Entry(item).State = EntityState.Modified;
                    

                   
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

