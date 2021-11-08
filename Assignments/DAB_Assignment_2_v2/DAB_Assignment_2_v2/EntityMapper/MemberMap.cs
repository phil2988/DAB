using DAB_Assignment_2_v2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAB_Assignment_2_v2.EntityMapper
{
    public class MemberMap : IEntityTypeConfiguration<Member>

    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(m => m.MemberId);
            builder.Property(m => m.MemberId).ValueGeneratedOnAdd();

            builder.HasMany(m => m.Keys)
                .WithOne(k => k.Member)
                .HasForeignKey(m => m.KeyId);
        }
    }
}