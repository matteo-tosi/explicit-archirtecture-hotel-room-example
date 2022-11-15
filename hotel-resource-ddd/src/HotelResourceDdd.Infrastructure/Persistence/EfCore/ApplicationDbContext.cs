using HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.OutOfServiceComponent.OutOfServiceAggregate.Configuration;
using HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.OutOfServiceComponent.OutOfServiceAggregate.Model;
using HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.RoomComponent.RoomAggregate.Configuration;
using HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.RoomComponent.RoomAggregate.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelResourceDdd.Infrastructure.Persistence.EfCore
{
    internal sealed class ApplicationDbContext : DbContext
    {
        public DbSet<OutOfServiceDb> OutOfService { get; set; }
        public DbSet<RoomDb> Room { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            _ = builder.ApplyConfiguration(new RoomEntityConfiguration());
            _ = builder.ApplyConfiguration(new OutOfServiceEntityConfiguration());
        }
    }
}
