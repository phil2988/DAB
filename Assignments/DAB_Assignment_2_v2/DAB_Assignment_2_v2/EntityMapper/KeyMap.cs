using DAB_Assignment_2_v2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAB_Assignment_2_v2.EntityMapper
{
    public class KeyMap : IEntityTypeConfiguration<Key>

    {
        public void Configure(EntityTypeBuilder<Key> builder)
        {
            //    builder.HasOne(r => r.Room)
            //        .WithOne(k => k.Key)
            //        .HasForeignKey(s => s.)

        }
    }
}
