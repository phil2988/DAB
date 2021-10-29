using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EfIntroSolution.Models;

namespace EfIntroSolution.Data
{
  public class AppDbContext : DbContext
  {

    public AppDbContext()
    { }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    public DbSet<Pc> pcs { get; set; }
    public DbSet<Laptop> laptops { get; set; }
    public DbSet<Printer> printers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      if (!options.IsConfigured)
      {
        options.UseSqlite("Data Source=products.db");
      }
    }



  }
}