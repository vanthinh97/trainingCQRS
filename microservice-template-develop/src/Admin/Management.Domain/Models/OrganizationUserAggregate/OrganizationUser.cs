using Microservices.Core.Domain.SeedWork;

namespace Management.Domain.Models.OrganizationUserAggregate
{
    public class OrganizationUser : Entity
    {
        public int UserId { get; set; }
        public int OrganizationId { get; set; }
    }
}
