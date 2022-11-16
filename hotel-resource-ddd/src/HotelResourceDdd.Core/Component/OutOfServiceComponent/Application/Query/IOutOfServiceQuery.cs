using HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Query.GetOutOfServiceValidity;

namespace HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Query
{
    public interface IOutOfServiceQuery
    {
        Task<GetOutOfServiceValidityQueryResponse?> GetOutOfServiceValidity(GetOutOfServiceValidityQuery request, CancellationToken cancellationToken = default);
    }
}
