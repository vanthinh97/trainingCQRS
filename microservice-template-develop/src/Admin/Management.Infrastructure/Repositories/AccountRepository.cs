using Management.Domain.Models.AccountAggregate;
using Management.Domain.Models.UserAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email) => await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
    }
}
