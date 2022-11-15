using DotNetExtensions.DomainAbstraction.Identity;

namespace HotelResourceDdd.Core.SharedKernel.Component.OutOfServiceComponent.OutOfServiceAggregate
{
    public sealed record class OutOfServiceId : AbstractNumberIdenty<int>
    {
        public OutOfServiceId(int id) : base(id)
        { }
    }
}
