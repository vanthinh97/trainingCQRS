using Microservices.Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Models.OrganizationAggregate
{
    public interface IOrganizationRepository : IRepository<Organization>
    {
        public Task<List<Organization>> GetListAsync(List<int> ids);
    }
}
