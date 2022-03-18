using Management.Domain.Models.GroupUserAggregate;
using Microservices.Core.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infrastructure.Repositories
{
    public class GroupUserRepository : Repository<GroupUser>, IGroupUserRepository
    {
        private new readonly ApplicationDbContext _context;
        public GroupUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<GroupUser>> GetGroupUserByUserIdAsync(int userId)
        {
            return _context.GroupUsers.Where(x => x.UserId == userId).ToListAsync();
        }

        public void RemoveListGroup(List<GroupUser> groupUsers)
        {
             _context.GroupUsers.RemoveRange(groupUsers);
        }
    }
}
