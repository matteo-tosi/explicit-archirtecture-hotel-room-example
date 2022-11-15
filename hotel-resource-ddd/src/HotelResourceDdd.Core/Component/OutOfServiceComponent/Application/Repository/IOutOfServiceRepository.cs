using DotNetExtensions.DomainAbstraction.Repository;
using HotelResourceDdd.Core.SharedKernel.Component.OutOfServiceComponent.OutOfServiceAggregate;

namespace HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Repository
{
    public interface IOutOfServiceRepository : IRepository<Domain.OutOfServiceAggregate.OutOfService, OutOfServiceId>
    { }
}
