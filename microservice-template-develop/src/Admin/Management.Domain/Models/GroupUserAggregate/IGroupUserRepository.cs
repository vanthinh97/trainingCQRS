using Microservices.Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Models.GroupUserAggregate
{
    public interface IGroupUserRepository : IRepository<GroupUser>
    {
        Task<List<GroupUser>> GetGroupUserByUserIdAsync(int userId);

        void RemoveListGroup(List<GroupUser> groupUsers);
    }
}
