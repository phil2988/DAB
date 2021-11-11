using DAB_Assignment_2_v2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAB_Assignment_2_v2.EntityMapper
{
    public class RoomMap : IEntityTypeConfiguration<Room>

    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(r => r.PropertyId).HasColumnType("uniqueidentifier");
            builder.HasKey(r => new { r.RoomKey, r.RoomAdress });

        }
    }
}
