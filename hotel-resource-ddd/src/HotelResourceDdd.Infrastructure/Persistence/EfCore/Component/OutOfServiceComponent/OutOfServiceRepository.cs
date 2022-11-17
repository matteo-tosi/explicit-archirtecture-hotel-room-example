using DotNetExtensions.LambdaExpression.Converter;
using DotNetExtensions.Mediator;
using HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Repository;
using HotelResourceDdd.Core.Component.OutOfServiceComponent.Domain.OutOfServiceAggregate;
using HotelResourceDdd.Core.SharedKernel.Component.OutOfServiceComponent.OutOfServiceAggregate;
using HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.OutOfServiceComponent.OutOfServiceAggregate.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.OutOfServiceComponent
{
    public class OutOfServiceRepository : IOutOfServiceRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IEventPublisher _notificationPublisher;

        public OutOfServiceRepository(ApplicationDbContext context, IEventPublisher notificationPublisher)
        {
            _context = context;
            _notificationPublisher = notificationPublisher;
        }

        public void Add(OutOfService entity)
            => _ = _context.Add(OutOfServiceDb.ConvertByModel(entity));

        public void AddRange(IEnumerable<OutOfService> entities)
            => _ = _context.Add(entities.Select(e => OutOfServiceDb.ConvertByModel(e)));

        public async Task<IEnumerable<OutOfService>> FindAsync(
            Expression<Func<OutOfService, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            var expressionConverter = new ExpressionConverter<OutOfService, OutOfServiceDb>();

            return await _context.OutOfService.Where((Expression<Func<OutOfServiceDb, bool>>)expressionConverter.ConvertPredicate(predicate))
                .Select(e => e.ConvertToModel())
                .ToListAsync(cancellationToken);
        }

        public async Task SaveAsync(OutOfService aggregateRoot, CancellationToken cancellationToken = default)
        {
            //TODO: è solo esemplificativo, va sicuramente strutturato meglio (con classe comune ai repository)

            _ = await _context.SaveChangesAsync(cancellationToken: cancellationToken);

            // Lancia tutti gli eventi di dominio
            foreach (var de in aggregateRoot.DomainEvents)
            {
                await _notificationPublisher.Publish(de, cancellationToken: cancellationToken);
            }

            // Resetta gli eventi
            aggregateRoot.ClearDomainEvents();
        }

        public Task<OutOfService> FirstOrDefaultAsync(
            Expression<Func<OutOfService, bool>> predicate,
            CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        public Task<OutOfService> LoadAsync(OutOfServiceId key,
            CancellationToken cancellationToken = default)
            => throw new NotImplementedException();

        public void Remove(OutOfService entity)
            => throw new NotImplementedException();

        public void RemoveRange(IEnumerable<OutOfService> entities)
            => throw new NotImplementedException();

        public Task<OutOfService> SingleOrDefaultAsync(
            Expression<Func<OutOfService, bool>> predicate,
            CancellationToken cancellationToken = default)
            => throw new NotImplementedException();
    }
}
