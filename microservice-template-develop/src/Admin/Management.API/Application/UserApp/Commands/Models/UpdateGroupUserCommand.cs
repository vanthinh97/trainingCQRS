using MediatR;
using Microservices.Core.API.Response;
using Microservices.Core.EventBus.CommandBus.Abstractions;
using System.Collections.Generic;

namespace Management.API.Application.UserApp.Commands.Models
{
    public class UpdateGroupUserCommand : RequestBase, IRequest<JsonResponse<int>>
    {
        public int UserId { get; set; }
        public List<int> GroupIds { get; set; }
    }
   
}
