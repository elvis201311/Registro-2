using Microsoft.EntityFrameworkCore;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registro.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Estudiantes> Estudiantes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\RegistroEstudiantes.db");
        }
    }
}