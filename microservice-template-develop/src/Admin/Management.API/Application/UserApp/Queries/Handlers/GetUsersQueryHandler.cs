using Management.API.Application.UserApp.Queries.Models;
using Management.Domain.Queries.UserAggregate;
using MediatR;
using Microservices.Core.API.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Management.API.Application.UserApp.Queries.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, JsonResponse<Pagination<UserDto>>>
    {
        private readonly IUserQueries _userQueries;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userQueries"></param>
        public GetUsersQueryHandler(IUserQueries userQueries)
        {
            _userQueries = userQueries;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<JsonResponse<Pagination<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userQueries.GetListAsync(request.Keyword, request.PageNumber, request.PageSize);
            return new OkResponse<Pagination<UserDto>> ("OK",new Pagination<UserDto>
            {
              //  TotalRecord = users.FirstOrDefault() != null ? users.FirstOrDefault().TotalRecord : 0,
                TotalRecord = users.FirstOrDefault()?.TotalRecord ?? 0,
                PageLists = users.ToList()
            });
        }
    }
}
