using HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.RoomComponent.RoomAggregate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.RoomComponent.RoomAggregate.Configuration
{
    internal class RoomEntityConfiguration : IEntityTypeConfiguration<RoomDb>
    {
        public void Configure(EntityTypeBuilder<RoomDb> builder)
        {
            // Nome della tabella
            _ = builder
                .ToTable("Room");

            // Primary key
            _ = builder
                .HasKey(x => x.Id);

            // Identity
            _ = builder
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            // Name max length and required
            _ = builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

            // Tratta questa property come value object:
            // https://learn.microsoft.com/it-it/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects#persist-value-objects-as-owned-entity-types-in-ef-core-20-and-later
            _ = builder
                .OwnsOne(r => r.State);
        }
    }
}
