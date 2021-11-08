using DAB_Assignment_2_v2.Models;
using Microsoft.EntityFrameworkCore;

namespace DAB_Assignment_2_v2.Architecture
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=BookstoreDB;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}