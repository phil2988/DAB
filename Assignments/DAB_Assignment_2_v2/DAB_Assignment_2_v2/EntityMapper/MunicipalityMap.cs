using DAB_Assignment_2_v2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAB_Assignment_2_v2.EntityMapper
{
    public class MunicipalityMap : IEntityTypeConfiguration<Municipality>

    {
        public void Configure(EntityTypeBuilder<Municipality> builder)
        {
            builder.HasKey(m => m.MunicipalityId);

        }
    }
}
