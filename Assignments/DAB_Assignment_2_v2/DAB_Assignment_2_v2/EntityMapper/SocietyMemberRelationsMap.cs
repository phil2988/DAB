using DAB_Assignment_2_v2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAB_Assignment_2_v2.EntityMapper
{
    public class SocietyMemberRelationsMap : IEntityTypeConfiguration<SocietyMemberRelations>

    {
        public void Configure(EntityTypeBuilder<SocietyMemberRelations> builder)
        {
            builder.HasNoKey();
        }
    }
}
