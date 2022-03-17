using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Management.Domain.Queries.UserAggregate
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        [IgnoreDataMember]
        public int TotalRecord { get; set; }
    }
}
