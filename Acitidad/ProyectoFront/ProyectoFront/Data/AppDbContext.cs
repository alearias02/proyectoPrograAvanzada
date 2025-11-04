using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProyectoFront.Models;
using System;

namespace ProyectoFront.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        
        public DbSet<ProductoModel> Producto { get; set; }
        public DbSet<ServicioModel> SERVICIOS { get; set; }
        public DbSet<CitaModel> CITAS { get; set; }
        public DbSet<UsuarioModel> UsuarioActivity { get; set; }

        
        public DbSet<LaboratoriosModel> Laboratorios { get; set; }
        public DbSet<Reservas> ReservasActivity { get; set; } 

        protected override void OnModelCreating(ModelBuilder mb)
        {
            
            mb.Entity<ProductoModel>().ToTable("Producto");
            mb.Entity<ServicioModel>().ToTable("SERVICIOS");
            mb.Entity<CitaModel>().ToTable("CITAS");
            mb.Entity<UsuarioModel>().ToTable("UsuarioActivity");

            mb.Entity<LaboratoriosModel>().ToTable("Laboratorios");
            mb.Entity<Reservas>().ToTable("Reservas");
        }
    }
}