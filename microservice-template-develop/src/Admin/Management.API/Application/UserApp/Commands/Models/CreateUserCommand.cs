using MediatR;
using Microservices.Core.API.Response;
using Microservices.Core.EventBus.CommandBus.Abstractions;
using System;
using System.Collections.Generic;

namespace Management.API.Application.UserApp.Commands.Models
{
    public class CreateUserCommand : RequestBase, IRequest<JsonResponse<int>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDay { get; set; }

        public List<int> GroupIds { get; set; }
        public List<int> OrganizationIds { get; set; }
    }
}
