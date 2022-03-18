using Microservices.Core.Domain.SeedWork;

namespace Management.Domain.Models.OrganizationUserAggregate
{
    public class OrganizationUser : EntityBase
    {
        public OrganizationUser(int organizationId)
        {
            OrganizationId = organizationId;
        }
        public int UserId { get; set; }
        public int OrganizationId { get; set; }

    }
}
