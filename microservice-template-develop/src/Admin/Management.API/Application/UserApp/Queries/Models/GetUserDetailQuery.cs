using Management.Domain.Queries.UserAggregate;
using MediatR;
using Microservices.Core.API.Response;
using Microservices.Core.EventBus.CommandBus.Abstractions;

namespace Management.API.Application.UserApp.Queries.Models
{
    public class GetUserDetailQuery : RequestBase, IRequest<JsonResponse<UserDetailDto>>
    {
        public int Id { get; set; }
    }
}
