using MediatR;
using Microservices.Core.API.Response;
using Microservices.Core.EventBus.CommandBus.Abstractions;

namespace Management.API.Application.UserApp.Commands.Models
{
    public class ChangePasswordCommand : RequestBase, IRequest<JsonResponse<int>>
    {
        public int Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
