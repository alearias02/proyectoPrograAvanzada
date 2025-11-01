using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProyectoFront.Models;
using System;

namespace ProyectoFront.Data
{
    public class AppDbContext : DbContext
    {
        //Creo un constructor vacio
        public AppDbContext ( DbContextOptions<AppDbContext> options ) : base(options)
        {

        }

        //Establcemos los modelos de datos.

        //      CREATE TABLE `u484426513_pac325`.`Producto` (
        //`Id` INT NOT NULL AUTO_INCREMENT,
        //`Nombre` VARCHAR(45) NOT NULL,
        //`Descripcion` VARCHAR(45) NOT NULL,
        //`Precio` DECIMAL NOT NULL,
        //`Cantidad` INT NOT NULL,
        //PRIMARY KEY(`Id`));
        public DbSet<ProductoModel> Producto { get; set; }
        public DbSet<ServicioModel> SERVICIOS { get; set; }

        public DbSet<CitaModel> CITAS { get; set; }

        public DbSet<UsuarioModel> UsuarioActivity { get; set; }

    }
}
