using DAB_Assignment_2_v2.EntityMapper;
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
            modelBuilder.ApplyConfiguration(new ActivityMap())
                .ApplyConfiguration(new SocietyMap())
                .ApplyConfiguration(new MunicipalityMap())
                .ApplyConfiguration(new RoomBookingMap())
                .ApplyConfiguration(new RoomPropertiesMap())
                .ApplyConfiguration(new RoomMap())
                .ApplyConfiguration(new KeyMap())
                .ApplyConfiguration(new MemberMap())
                .ApplyConfiguration(new SocietyMemberRelationsMap());
        }
    }
}