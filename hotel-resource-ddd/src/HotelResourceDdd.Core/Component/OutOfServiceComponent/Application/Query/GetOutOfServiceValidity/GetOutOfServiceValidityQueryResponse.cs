namespace HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Query.GetOutOfServiceValidity
{
    public sealed class GetOutOfServiceValidityQueryResponse
    {
        public int OutOfServiceId { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime? End { get; private set; }

        public GetOutOfServiceValidityQueryResponse(int outOfServiceId, DateTime start, DateTime? end)
        {
            this.OutOfServiceId = outOfServiceId;
            this.Start = start;
            this.End = end;
        }
    }
}
