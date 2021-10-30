using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTest
{
    class MyDbContext : DbContext
    {
        public DbSet<Person> people { get; set; }
        public DbSet<Car> cars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Car>()
                .HasKey(a => a.LicensePlate);

            mb.Entity<Person>()
                .HasOne(a => a.Car)
                .WithOne()
                .HasForeignKey<Car>();
        }
    }
}
