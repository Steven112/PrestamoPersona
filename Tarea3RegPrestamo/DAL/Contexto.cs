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


    }
}
