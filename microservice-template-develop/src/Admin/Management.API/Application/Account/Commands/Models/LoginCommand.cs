using Management.Domain.Models.AccountAggregate;
using MediatR;
using Microservices.Core.API.Response;
using Microservices.Core.EventBus.CommandBus.Abstractions;

namespace Management.API.Application.Account.Commands.Models
{
    public class LoginCommand : IRequest<JsonResponse<UserLoginDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
