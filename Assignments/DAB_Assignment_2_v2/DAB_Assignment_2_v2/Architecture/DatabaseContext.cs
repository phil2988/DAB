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

        private readonly string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>{
                entity.HasKey(x => x.ActivityId);
                entity.Property(x => x.ActivityId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Member>(entity =>{
                entity.HasKey(m => m.MemberId);
                entity.Property(m => m.MemberId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Municipality>(entity =>{
                entity.HasKey(m => m.MunicipalityId);
            });

            modelBuilder.Entity<RoomBooking>(entity => {
                entity.HasKey(r => r.BookingId);

                entity
                    .HasOne(rb => rb.Room);

            });

            modelBuilder.Entity<Room>(entity => {
                entity.Property(r => r.PropertyId).HasColumnType("uniqueidentifier");
                entity.HasKey(r => new { r.RoomKey, r.RoomAdress });
            });

            modelBuilder.Entity<RoomProperties>(entity => {
                entity.HasKey(p => p.PropertyId);
                entity.Property(r => r.PropertyId).HasColumnType("uniqueidentifier");
                entity.Property(p => p.PropertyId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Society>(entity => {
                entity.HasKey(s => s.SocietyId);
                entity.Property(s => s.SocietyId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<SocietyMemberRelations>(entity => {
                entity
                    .HasKey(k => new { k.MemberId, k.SocietyId });

                entity
                    .HasOne(smr => smr.Member)
                    .WithMany(m => m.SocietyMemberRelations)
                    .HasForeignKey(smr => smr.MemberId);

                entity
                    .HasOne(smr => smr.Society)
                    .WithMany(s => s.SocietyMemberRelations)
                    .HasForeignKey(smr => smr.SocietyId);
            });

            modelBuilder.Entity<Key>(entity => {
                entity.HasKey(k => k.KeyId);

            });
        }
    }
}