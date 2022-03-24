using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Queries.UserAggregate
{
    public interface IUserQueries
    {
        Task<IEnumerable<UserDto>> GetListAsync(
            int? isActive,
            int? arrangeType, 
            string keyword, 
            List<int?> roleIds, 
            string fromDate,
            string toDate,
            int? pageNumber, 
            int? pageSize);
        Task<UserDetailDto> GetDetailAsync(int id);

    }
}
