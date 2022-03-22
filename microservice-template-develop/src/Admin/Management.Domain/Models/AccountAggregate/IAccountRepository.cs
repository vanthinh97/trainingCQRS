using Management.Domain.Models.UserAggregate;
using Microservices.Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Models.AccountAggregate
{
    public interface IAccountRepository
    {
        Task<User> GetByEmailAsync(string email);
    }
}
