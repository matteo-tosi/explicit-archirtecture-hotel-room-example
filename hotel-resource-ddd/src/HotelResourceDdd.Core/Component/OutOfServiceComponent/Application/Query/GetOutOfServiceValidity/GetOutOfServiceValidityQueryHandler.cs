using DotNetExtensions.DomainAbstraction.Event;

namespace HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Query.GetOutOfServiceValidity
{
    internal class GetOutOfServiceValidityQueryHandler : AbstractEventHandler<GetOutOfServiceValidityQuery, GetOutOfServiceValidityQueryResponse>
    {
        public GetOutOfServiceValidityQueryHandler()
        {

        }

        public override async Task<GetOutOfServiceValidityQueryResponse> Handle(GetOutOfServiceValidityQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
