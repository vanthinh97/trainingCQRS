using Management.Domain.Models.GroupUserAggregate;
using Microservices.Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Domain.Models.GroupAggregate
{
    public class Group : Entity
    {
        private List<GroupUser> _groupUsers;
        public Group()
        {
           _groupUsers = new List<GroupUser>();
        }

        /// <summary>
        /// Hàm khởi tạo của lớp <see cref="Group"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <param name="description"></param>
        public Group(string name, string code, string description)
        {
            Name = name;
            Code = code;
            Description = description;
        }
        public IReadOnlyCollection<GroupUser> GroupUsers => _groupUsers ??= new List<GroupUser>();

        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

      //  public ICollection<GroupUser> groupUsers { get; set; }
    }
}
