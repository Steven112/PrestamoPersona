using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea3RegPrestamo.Models;

namespace Tarea3RegPrestamo.DAL
{
    public class Contexto:DbContext
    {
        public DbSet<Persona> personas { get; set; }
        public DbSet<Prestamos> prestamos { get; set; }
        public DbSet<Mora> moras { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\TeacherControl.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().HasData(new Persona
            {
                PersonaId = 1,
                Normbre = "Steven Caceres",
                Cedula = "789-9632598-1",
                Telofono = "829-635-5478",
                Direccion = "C/ Maximo Gomez, Casa#3",
                FechaNacimiento = DateTime.Now,
                Balance=10

            });
            modelBuilder.Entity<Prestamos>().HasData(new Prestamos
            {
                PrestamoId = 1,
                PersonaId = 1,
                Concepto="Compra de carro",
                Monto=10,

            });

           
        }


    }
}
