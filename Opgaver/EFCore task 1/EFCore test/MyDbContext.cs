using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_test 
{
    class MyDbContext : DbContext
    {
        public DbSet<Door> doors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
    public class Door
    {
        [Required]
        public int DoorId { get; set; }
        public bool Windows { get; set; }
        public string Type { get; set; }
    }
}
