using Microservices.Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Models.UserAggregate
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);

        Task<User> GetUserByIdAsync(int id);

        Task<List<User>> GetListAsync(List<int> ids);
    }
}
