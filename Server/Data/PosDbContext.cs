using Microsoft.EntityFrameworkCore;
using POS_Papeleria_Terrones.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS_Papeleria_Terrones.Server.Data
{
   public class PosDbContext : DbContext
   {
      public PosDbContext(DbContextOptions<PosDbContext> options) : base(options)
      {

      }
      public DbSet<Articulo> Articulos { get; set; }
      public DbSet<Categoria> Categorias { get; set; }
      public DbSet<Entrada> Entradas { get; set; }
      public DbSet<Salida> Salidas { get; set; }
   }
}
