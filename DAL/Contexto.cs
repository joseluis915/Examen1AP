using System;
using System.Collections.Generic;
using System.Text;
using Examen1AP.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Examen1AP.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Ciudades> Ciudades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\Ciudades.db");
        }
    }
}