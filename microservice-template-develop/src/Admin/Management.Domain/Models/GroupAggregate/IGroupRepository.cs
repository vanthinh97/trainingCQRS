using Microservices.Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Models.GroupAggregate
{
    public interface IGroupRepository : IRepository<Group>
    {
        public Task<List<Group>> GetListAsync(List<int> ids);
    }
}
