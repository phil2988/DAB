using DAB_Assignment_2_v2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAB_Assignment_2_v2.EntityMapper
{
    public class SocietyMap : IEntityTypeConfiguration<Society>

    {
        public void Configure(EntityTypeBuilder<Society> builder)
        {
            builder.HasKey(s => s.SocietyId);
            builder.Property(s => s.SocietyId).ValueGeneratedOnAdd();
        }
    }
}