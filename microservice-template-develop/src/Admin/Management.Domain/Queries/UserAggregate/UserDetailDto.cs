using Management.Domain.Queries.GroupAggregate;
using System;
using System.Collections.Generic;

namespace Management.Domain.Queries.UserAggregate
{
    public class UserDetailDto
    {
        public UserDetailDto(string fullName, string email, int roleId, List<GroupDto> groupDtos)
        {
            FullName = fullName;
            Email = email;
            RoleId = roleId;
            this.groupDtos = groupDtos;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public DateTime? BirthDay { get; set; }
        public List<GroupDto> groupDtos { get; set; }
    }
}
