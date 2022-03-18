using Management.Domain.Queries.GroupAggregate;
using System;
using System.Collections.Generic;

namespace Management.Domain.Queries.UserAggregate
{
    public class UserDetailDto
    {
        public UserDetailDto(string firstName, string email, List<GroupDto> groupDtos)
        {
            FirstName = firstName;
            Email = email;
            this.groupDtos = groupDtos;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDay { get; set; }
        public List<GroupDto> groupDtos { get; set; }
    }
}
