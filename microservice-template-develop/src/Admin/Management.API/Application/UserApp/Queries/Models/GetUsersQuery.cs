using Management.Domain.Queries.UserAggregate;
using MediatR;
using Microservices.Core.API.Response;

namespace Management.API.Application.UserApp.Queries.Models
{
    public class GetUsersQuery : IRequest<JsonResponse<Pagination<UserDto>>>
    {
        public string Keyword { get; set; }
        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }
    }
}
