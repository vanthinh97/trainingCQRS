using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Queries.UserAggregate
{
    public interface IUserQueries
    {
        Task<IEnumerable<UserDto>> GetListAsync(string keyword, int? pageNumber, int? pageSize);
        Task<UserDetailDto> GetDetailAsync(int id);

    }
}
