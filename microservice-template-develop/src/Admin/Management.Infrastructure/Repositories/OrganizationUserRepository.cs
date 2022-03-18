using Management.Domain.Models.OrganizationUserAggregate;
using Microservices.Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Infrastructure.Repositories
{
    public class OrganizationUserRepository : Repository<OrganizationUser>, IOrganizationUserRepository
    {
        public OrganizationUserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
