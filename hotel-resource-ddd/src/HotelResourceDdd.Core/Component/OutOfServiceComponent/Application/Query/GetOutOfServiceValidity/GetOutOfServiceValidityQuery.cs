using DotNetExtensions.DomainAbstraction.Event.Cqrs;

namespace HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Query.GetOutOfServiceValidity
{
    public sealed class GetOutOfServiceValidityQuery : AbstractQueryEvent<GetOutOfServiceValidityQueryResponse>
    {
        public int OutOfServiceId { get; private set; }

        public GetOutOfServiceValidityQuery(int outOfServiceId)
        {
            this.OutOfServiceId = outOfServiceId;
        }
    }
}
