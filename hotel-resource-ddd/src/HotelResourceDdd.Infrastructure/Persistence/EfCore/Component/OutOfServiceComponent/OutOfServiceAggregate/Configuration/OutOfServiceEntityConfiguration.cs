using HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.OutOfServiceComponent.OutOfServiceAggregate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.OutOfServiceComponent.OutOfServiceAggregate.Configuration
{
    internal class OutOfServiceEntityConfiguration : IEntityTypeConfiguration<OutOfServiceDb>
    {
        public void Configure(EntityTypeBuilder<OutOfServiceDb> builder)
        {
            // Nome della tabella
            _ = builder
                .ToTable("OutOfService");

            // Primary key
            _ = builder
                .HasKey(x => x.Id);

            // Identity
            _ = builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            _ = builder
                .Property(x => x.RoomId)
                .IsRequired();

            // In
            _ = builder
                .Property(x => x.In)
                .IsRequired()
                .HasConversion(
                    date => date,
                    date => DateTime.SpecifyKind(date, DateTimeKind.Utc));

            // Out
            _ = builder
                .Property(x => x.Out)
                .HasConversion(
                    date => date,
                    date => date == null ? null : DateTime.SpecifyKind(date.Value, DateTimeKind.Utc));
        }
    }
}
