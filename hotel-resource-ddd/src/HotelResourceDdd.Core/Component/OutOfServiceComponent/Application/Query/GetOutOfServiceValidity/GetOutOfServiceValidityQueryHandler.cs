using DotNetExtensions.CqrsAbstraction.Query;

namespace HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Query.GetOutOfServiceValidity
{
    internal class GetOutOfServiceValidityQueryHandler : IQueryHandler<GetOutOfServiceValidityQuery, GetOutOfServiceValidityQueryResponse?>
    {
        private readonly IOutOfServiceQuery _outOfServiceQuery;
        public GetOutOfServiceValidityQueryHandler(IOutOfServiceQuery outOfServiceQuery)
        {
            _outOfServiceQuery = outOfServiceQuery;
        }

        public async Task<GetOutOfServiceValidityQueryResponse?> Handle(GetOutOfServiceValidityQuery request, CancellationToken cancellationToken)
            => await _outOfServiceQuery.GetOutOfServiceValidity(request, cancellationToken: cancellationToken);
    }
}
