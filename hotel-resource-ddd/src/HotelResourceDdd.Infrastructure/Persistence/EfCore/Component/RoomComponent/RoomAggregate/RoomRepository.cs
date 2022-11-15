using DotNetExtensions.LambdaExpression.Converter;
using HotelResourceDdd.Core.Component.RoomComponent.Application.Repository;
using HotelResourceDdd.Core.Component.RoomComponent.Domain.RoomAggregate;
using HotelResourceDdd.Core.Port.EventManager;
using HotelResourceDdd.Core.SharedKernel.Component.RoomComponent.RoomAggregate;
using HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.RoomComponent.RoomAggregate.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.RoomComponent.RoomAggregate
{
    internal class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IEventManager _eventManager;

        public RoomRepository(ApplicationDbContext context, IEventManager eventManager)
        {
            _context = context;
            _eventManager = eventManager;
        }

        public void Add(Room entity)
            => _ = _context.Add(ConvertByModel(entity));

        public void AddRange(IEnumerable<Room> entities)
            => _ = _context.Add(entities.Select(e => ConvertByModel(e)));

        public async Task<IEnumerable<Room>> FindAsync(
            Expression<Func<Room, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var expressionConverter = new ExpressionConverter<Room, RoomDb>();

            return await _context.Room.Where((Expression<Func<RoomDb, bool>>)expressionConverter.ConvertPredicate(predicate))
                .Select(e => ConvertToModel(e))
                .ToListAsync(cancellationToken);
        }

        public async Task SaveAsync(Room aggregateRoot, CancellationToken cancellationToken = default)
        {
            //TODO: è solo esemplificativo, va sicuramente strutturato meglio (con classe comune ai repository)

            _ = await _context.SaveChangesAsync(cancellationToken: cancellationToken);

            // Lancia tutti gli eventi di dominio
            foreach (var de in aggregateRoot.DomainEvents)
            {
                await _eventManager.Publish(de, cancellationToken: cancellationToken);
            }

            // Resetta gli eventi
            aggregateRoot.ClearDomainEvents();
        }

        public Task<Room> FirstOrDefaultAsync(
            Expression<Func<Room, bool>> predicate, CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        public Task<Room> LoadAsync(RoomId key, CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        public void Remove(Room entity)
            => throw new NotImplementedException();

        public void RemoveRange(IEnumerable<Room> entities)
            => throw new NotImplementedException();

        public Task<Room> SingleOrDefaultAsync(
            Expression<Func<Room, bool>> predicate, CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        private static Room ConvertToModel(RoomDb entity)
            => new(new RoomId(entity.Id), new Core.SharedKernel.ValueObject.LicenseNumber(entity.LicenseNumber), entity.Name);

        private static RoomDb ConvertByModel(Room entity)
            => new()
            {
                Id = entity.Id.Value,
                LicenseNumber = entity.LicenseNumber.Value,
                Name = entity.Name,
                State = entity.State
            };
    }
}
