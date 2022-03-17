using Management.API.Application.UserApp.Queries.Models;
using Management.Domain.Queries.UserAggregate;
using MediatR;
using Microservices.Core.API.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Management.API.Application.UserApp.Queries.Handlers
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, JsonResponse<UserDetailDto>>
    {
        private readonly IUserQueries _userQueries;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userQueries"></param>
        public GetUserDetailQueryHandler(IUserQueries userQueries)
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
        public async Task<JsonResponse<UserDetailDto>> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userQueries.GetDetailAsync(request.Id);
            return new OkResponse<UserDetailDto>("OK", user);
        }
    }
}
