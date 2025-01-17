﻿using DotNetExtensions.DomainAbstraction.Event.Domain;
using HotelResourceDdd.Core.SharedKernel.Component.OutOfServiceComponent.OutOfServiceAggregate.Event;
using Microsoft.Extensions.Caching.Memory;

namespace HotelResourceDdd.Infrastructure.Caching.InMemory.Listener
{
    internal class OutOfServiceCacheReloadListener : AbstractDomainEventHandler<NewOutOfServiceAddedEvent>
    {
        private readonly IMemoryCache _cache;

        public OutOfServiceCacheReloadListener(IMemoryCache cache)
        {
            _cache = cache;
        }

        public override Task Handle(NewOutOfServiceAddedEvent notification, CancellationToken cancellationToken = default)
        {
            _cache.Remove(notification.OutOfServiceId);

            return Task.CompletedTask;
        }
    }
}
