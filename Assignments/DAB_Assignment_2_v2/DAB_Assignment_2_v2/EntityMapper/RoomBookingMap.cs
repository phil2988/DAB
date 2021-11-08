using DAB_Assignment_2_v2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAB_Assignment_2_v2.EntityMapper
{
    public class RoomBookingMap : IEntityTypeConfiguration<RoomBooking>

    {
        public void Configure(EntityTypeBuilder<RoomBooking> builder)
        {
            builder.HasOne(r => r.Room)
                 .WithMany(r => r.BookingIds)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
