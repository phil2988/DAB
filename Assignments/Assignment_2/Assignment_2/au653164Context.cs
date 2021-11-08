using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Assignment_2.Tables;
using MongoDB.Driver;


#nullable disable

namespace Assignment_2
{
    public partial class au653164Context : DbContext
    {
        public au653164Context()
        {
        }

        public au653164Context(DbContextOptions<au653164Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Chairman> Chairmen { get; set; }
        public virtual DbSet<LocationProperty> LocationProperties { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Municipality> Municipalities { get; set; }
        public virtual DbSet<MunicipalityLocation> MunicipalityLocations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Society> Societies { get; set; }
        public virtual DbSet<SocietyMemberRelation> SocietyMemberRelations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasKey(e => e.ActivityName)
                    .HasName("PK__Activity__BD8CC0A8B21D014C");

                entity.ToTable("Activity");

                entity.Property(e => e.ActivityName)
                    .HasMaxLength(50)
                    .HasColumnName("activityName");
            });

            modelBuilder.Entity<Chairman>(entity =>
            {
                entity.HasKey(e => e.ChairmanName)
                    .HasName("PK__Chairman__1BC12E7435675000");

                entity.ToTable("Chairman");

                entity.Property(e => e.ChairmanName)
                    .HasMaxLength(50)
                    .HasColumnName("chairmanName");

                entity.Property(e => e.Adress)
                    .HasMaxLength(50)
                    .HasColumnName("_adress");

                entity.Property(e => e.Cpr).HasColumnName("_cpr");

                entity.Property(e => e.LocationAdress)
                    .HasMaxLength(50)
                    .HasColumnName("locationAdress");

                entity.Property(e => e.RoomKey).HasColumnName("roomKey");
            });

            modelBuilder.Entity<LocationProperty>(entity =>
            {
                entity.HasKey(e => e.PropertyId)
                    .HasName("PK__Location__9C0B8C7D6BFF421A");

                entity.ToTable("Location_Properties");

                entity.Property(e => e.PropertyId).HasColumnName("propertyId");

                entity.Property(e => e.Chairs).HasColumnName("_chairs");

                entity.Property(e => e.CoffeeMachine).HasColumnName("_coffeeMachine");

                entity.Property(e => e.SoccerGoals).HasColumnName("_soccerGoals");

                entity.Property(e => e.SoundSystem).HasColumnName("_soundSystem");

                entity.Property(e => e.Tables).HasColumnName("_tables");

                entity.Property(e => e.Toilet).HasColumnName("_toilet");

                entity.Property(e => e.Water).HasColumnName("_water");

                entity.Property(e => e.Whiteboard).HasColumnName("_whiteboard");

                entity.Property(e => e.Wifi).HasColumnName("_wifi");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.Property(e => e.MemberId).HasColumnName("memberId");

                entity.Property(e => e.Adress)
                    .HasMaxLength(50)
                    .HasColumnName("_adress");

                entity.Property(e => e.Cpr).HasColumnName("_cpr");

                entity.Property(e => e.LocationAdress)
                    .HasMaxLength(50)
                    .HasColumnName("locationAdress");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("_name");

                entity.Property(e => e.RoomId).HasColumnName("roomId");

                entity.HasOne(d => d.LocationAdressNavigation)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.LocationAdress)
                    .HasConstraintName("FK_Member.locationAdress");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_Member.roomId");
            });

            modelBuilder.Entity<Municipality>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Municipality");

                entity.Property(e => e.SocietyCvr).HasColumnName("societyCvr");

                entity.HasOne(d => d.SocietyCvrNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.SocietyCvr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Municipality.societyCvr");
            });

            modelBuilder.Entity<MunicipalityLocation>(entity =>
            {
                entity.HasKey(e => e.LocationAdress)
                    .HasName("PK__Municipa__4FAFE91BB12ECCA8");

                entity.ToTable("Municipality_Location");

                entity.Property(e => e.LocationAdress)
                    .HasMaxLength(50)
                    .HasColumnName("locationAdress");

                entity.Property(e => e.LocationAvailabilityStart).HasColumnName("_locationAvailabilityStart");

                entity.Property(e => e.LocationAvailabilityStop).HasColumnName("_locationAvailabilityStop");

                entity.Property(e => e.MaxMembers).HasColumnName("_maxMembers");

                entity.Property(e => e.PropertyId).HasColumnName("propertyId");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.MunicipalityLocations)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("FK.Municipality_Location.propertyId");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomId).HasColumnName("roomId");

                //entity.Property(e => e.RoomBookings).HasColumnName("roomBookings");

                entity.Property(e => e.LocationAdress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("locationAdress");

                entity.Property(e => e.MaxMembers).HasColumnName("_maxMembers");

                entity.Property(e => e.RoomAvailabilityStart).HasColumnName("_roomAvailabilityStart");

                entity.Property(e => e.RoomAvailabilityStop).HasColumnName("_roomAvailabilityStop");

                entity.Property(e => e.RoomKey).HasColumnName("_roomKey");

                entity.HasOne(d => d.LocationAdressNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.LocationAdress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room.locationAdress");

                entity.HasOne(d => d.RoomBookings)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room.RoomId");
            });
            
            modelBuilder.Entity<Society>(entity =>
            {
                entity.HasKey(e => e.SocietyCvr)
                    .HasName("PK__Society__41BA8D9C58F8827D");

                entity.ToTable("Society");

                entity.Property(e => e.SocietyCvr)
                    .ValueGeneratedNever()
                    .HasColumnName("societyCvr");

                entity.Property(e => e.ActivityName)
                    .HasMaxLength(50)
                    .HasColumnName("activityName");

                entity.Property(e => e.ChairmanName)
                    .HasMaxLength(50)
                    .HasColumnName("chairmanName");

                entity.Property(e => e.SocietyAdress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("_societyAdress");

                entity.Property(e => e.SocietyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("_societyName");

                entity.HasOne(d => d.ActivityNameNavigation)
                    .WithMany(p => p.Societies)
                    .HasForeignKey(d => d.ActivityName)
                    .HasConstraintName("FK_Society.activityName");

                entity.HasOne(d => d.ChairmanNameNavigation)
                    .WithMany(p => p.Societies)
                    .HasForeignKey(d => d.ChairmanName)
                    .HasConstraintName("FK_Society.chairmanName");
            });

            modelBuilder.Entity<SocietyMemberRelation>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => new { e.MemberId, e.SocietyCvr }, "UQ__SocietyM__ABCC67CEC7F0F4D5")
                    .IsUnique();

                entity.Property(e => e.MemberId).HasColumnName("memberId");

                entity.Property(e => e.SocietyCvr).HasColumnName("societyCvr");

                entity.HasOne(d => d.Member)
                    .WithMany()
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SocietyMe__membe__37A5467C");

                entity.HasOne(d => d.SocietyCvrNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.SocietyCvr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SocietyMe__socie__36B12243");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
