using DotNetExtensions.DomainAbstraction.Event;

namespace HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Query.GetOutOfServiceValidity
{
    internal class GetOutOfServiceValidityQueryHandler : AbstractSingleEventHandler<GetOutOfServiceValidityQuery, GetOutOfServiceValidityQueryResponse?>
    {
        private readonly IOutOfServiceQuery _outOfServiceQuery;
        public GetOutOfServiceValidityQueryHandler(IOutOfServiceQuery outOfServiceQuery)
        {
            _outOfServiceQuery = outOfServiceQuery;
        }

        public override async Task<GetOutOfServiceValidityQueryResponse?> Handle(GetOutOfServiceValidityQuery request, CancellationToken cancellationToken)
            => await _outOfServiceQuery.GetOutOfServiceValidity(request, cancellationToken: cancellationToken);
    }
}
