using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Domain.Queries.UserAggregate
{
    public class UserDetailDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}
