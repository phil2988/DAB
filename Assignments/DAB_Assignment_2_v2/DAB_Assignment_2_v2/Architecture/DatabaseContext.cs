using DAB_Assignment_2_v2.EntityMapper;
using Microsoft.EntityFrameworkCore;

namespace DAB_Assignment_2_v2.Architecture
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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