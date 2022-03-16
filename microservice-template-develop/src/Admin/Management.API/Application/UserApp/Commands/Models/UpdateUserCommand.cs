using MediatR;
using Microservices.Core.API.Response;
using Microservices.Core.EventBus.CommandBus.Abstractions;
using System;

namespace Management.API.Application.UserApp.Commands.Models
{
    public class UpdateUserCommand : RequestBase, IRequest<JsonResponse<int>>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}
