using MediatR;
using Microservices.Core.API.Response;
using Microservices.Core.EventBus.CommandBus.Abstractions;
using System.Collections.Generic;

namespace Management.API.Application.UserApp.Commands.Models
{
    public class DeleteUsersCommand : RequestBase, IRequest<JsonResponse<int>>
    {
        public List<int> Ids { get; set; }
    }
}
