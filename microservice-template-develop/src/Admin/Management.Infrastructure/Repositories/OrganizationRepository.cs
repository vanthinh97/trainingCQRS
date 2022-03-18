using Management.Domain.Models.OrganizationAggregate;
using Microservices.Core.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.Infrastructure.Repositories
{
    public class OrganizationRepository : Repository<Organization>, IOrganizationRepository
    {
        private new readonly ApplicationDbContext _context;
        public OrganizationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public Task<List<Organization>> GetListAsync(List<int> ids)
        {
            return _context.Organizations.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
