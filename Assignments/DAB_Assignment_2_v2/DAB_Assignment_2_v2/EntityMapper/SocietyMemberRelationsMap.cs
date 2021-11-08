using DAB_Assignment_2_v2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAB_Assignment_2_v2.EntityMapper
{
    public class SocietyMemberRelationsMap : IEntityTypeConfiguration<SocietyMemberRelations>

    {
        public void Configure(EntityTypeBuilder<SocietyMemberRelations> builder)
        {
            builder.HasKey(smr => new { smr.MemberId, smr.SocietyId });

            builder.HasOne(smr => smr.Society)
                .WithMany(s => s.SocietyMemberRelations)
                .HasForeignKey(smr => smr.SocietyId);

            builder.HasOne(smr => smr.Member)
                .WithMany(s => s.SocietyMemberRelations)
                .HasForeignKey(smr => smr.MemberId);
        }
    }
}
