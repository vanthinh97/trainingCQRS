using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Management.Domain.Queries.UserAggregate
{
    public class UserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int IsDeleted { get; set; }
        [IgnoreDataMember]
        public int TotalRecord { get; set; }
    }
}
