using Management.Domain.Models.GroupUserAggregate;
using Microservices.Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Infrastructure.Repositories
{
    public class GroupUserRepository : Repository<GroupUser>, IGroupUserRepository
    {
        public GroupUserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
