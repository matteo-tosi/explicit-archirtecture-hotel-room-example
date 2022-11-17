using HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Query;
using HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Query.GetOutOfServiceValidity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.OutOfServiceComponent.OutOfServiceAggregate.Query
{
    public class OutOfServiceQuery : IOutOfServiceQuery
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMemoryCache _cache;

        public OutOfServiceQuery(ApplicationDbContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        public async Task<GetOutOfServiceValidityQueryResponse?> GetOutOfServiceValidity(GetOutOfServiceValidityQuery request,
            CancellationToken cancellationToken = default)
        {
            // Gestione cache
            if (_cache.TryGetValue(request.OutOfServiceId, out GetOutOfServiceValidityQueryResponse? response))
            {
                return response;
            }

            var result = await _dbContext.OutOfService
                .Where(o => o.Id == request.OutOfServiceId)
                .Select(o => new GetOutOfServiceValidityQueryResponse(o.Id, o.In, o.Out))
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return _cache.Set(request.OutOfServiceId, result);
        }
    }
}
