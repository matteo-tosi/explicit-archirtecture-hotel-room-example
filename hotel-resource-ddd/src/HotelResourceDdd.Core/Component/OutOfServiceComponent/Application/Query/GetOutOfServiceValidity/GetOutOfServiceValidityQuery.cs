using DotNetExtensions.DomainAbstraction.Event;

namespace HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Query.GetOutOfServiceValidity
{
    public sealed class GetOutOfServiceValidityQuery : AbstractEvent<GetOutOfServiceValidityQueryResponse>
    {
        public int OutOfServiceId { get; private set; }

        public GetOutOfServiceValidityQuery(int outOfServiceId)
        {
            this.OutOfServiceId = outOfServiceId;
        }
    }
}
