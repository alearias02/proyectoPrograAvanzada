using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProyectoG2.Models;
using System;

namespace ProyectoG2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext ( DbContextOptions<AppDbContext> options ) : base(options)
        {

        }



    }
}
