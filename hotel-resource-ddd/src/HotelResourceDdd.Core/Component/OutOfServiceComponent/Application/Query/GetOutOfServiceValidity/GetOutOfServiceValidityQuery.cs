using DotNetExtensions.DomainAbstraction.Event;

namespace HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Query.GetOutOfServiceValidity
{
    public sealed class GetOutOfServiceValidityQuery : AbstractSingleEvent<GetOutOfServiceValidityQueryResponse>
    {
        public int OutOfServiceId { get; private set; }

        public GetOutOfServiceValidityQuery(int outOfServiceId)
        {
            this.OutOfServiceId = outOfServiceId;
        }
    }
}
