using Management.Domain.Models.GroupAggregate;
using Microservices.Core.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.Infrastructure.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        private new readonly ApplicationDbContext _context;
        public GroupRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public Task<List<Group>> GetListAsync(List<int> ids)
        {
            return _context.Groups.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
