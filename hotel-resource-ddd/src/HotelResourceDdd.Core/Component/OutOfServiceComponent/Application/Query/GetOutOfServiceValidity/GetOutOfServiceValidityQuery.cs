using DotNetExtensions.CqrsAbstraction.Query;

namespace HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Query.GetOutOfServiceValidity
{
    public sealed class GetOutOfServiceValidityQuery : IQuery
    {
        public int OutOfServiceId { get; private set; }

        public GetOutOfServiceValidityQuery(int outOfServiceId)
        {
            this.OutOfServiceId = outOfServiceId;
        }
    }
}
