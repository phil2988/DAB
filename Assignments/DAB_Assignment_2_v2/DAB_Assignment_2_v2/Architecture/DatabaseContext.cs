using DAB_Assignment_2_v2.EntityMapper;
using DAB_Assignment_2_v2.Models;
using Microsoft.EntityFrameworkCore;

namespace DAB_Assignment_2_v2.Architecture
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Key> Key { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Municipality> Municipality { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomBooking> RoomBooking { get; set; }
        public DbSet<RoomProperties> RoomProperties { get; set; }
        public DbSet<Society> Society { get; set; }
        public DbSet<SocietyMemberRelations> SocietyMemberRelations { get; set; }

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

            modelBuilder.Entity<Society>().Ignore(e => e.Chairman);
        }
    }
}