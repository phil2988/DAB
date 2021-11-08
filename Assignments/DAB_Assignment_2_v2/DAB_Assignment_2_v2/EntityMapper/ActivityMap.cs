using DAB_Assignment_2_v2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAB_Assignment_2_v2.EntityMapper
{
    public class ActivityMap : IEntityTypeConfiguration<Activity>

    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(x => x.ActivityId);
            builder.Property(x => x.ActivityId).ValueGeneratedOnAdd();
        }
    }
}
