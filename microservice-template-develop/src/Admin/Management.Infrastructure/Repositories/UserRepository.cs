using Management.Domain.Models.UserAggregate;
using Microservices.Core.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private new readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int id) => await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        public async Task<User> GetByEmailAsync(string email) => await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());

        public Task<List<User>> GetListAsync(List<int> ids)
        {
           return _context.Users.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
