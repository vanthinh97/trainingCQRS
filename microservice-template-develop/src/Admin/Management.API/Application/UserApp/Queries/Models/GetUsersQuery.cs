using Management.Domain.Queries.UserAggregate;
using MediatR;
using Microservices.Core.API.Response;
using System.Collections.Generic;

namespace Management.API.Application.UserApp.Queries.Models
{
    public class GetUsersQuery : IRequest<JsonResponse<Pagination<UserDto>>>
    {
        public int? isActive { get; set; }
        public int? ArrangeType { get; set; }
        public string Keyword { get; set; }
        public List<int?> RoleIds { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

    }
}
