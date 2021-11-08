using DAB_Assignment_2_v2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAB_Assignment_2_v2.EntityMapper
{
    public class RoomPropertiesMap : IEntityTypeConfiguration<RoomProperties>

    {
        public void Configure(EntityTypeBuilder<RoomProperties> builder)
        {
            builder.HasKey(p => p.PropertyId);
            builder.Property(p => p.PropertyId).ValueGeneratedOnAdd();
            
        }
    }
}
