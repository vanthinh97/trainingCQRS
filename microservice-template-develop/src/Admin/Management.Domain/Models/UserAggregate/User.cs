using Management.Domain.Models.GroupUserAggregate;
using Management.Domain.Models.OrganizationUserAggregate;
using Microservices.Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Domain.Models.UserAggregate
{
    public class User : Entity
    {
        private List<GroupUser> _groupUsers;
        private List<OrganizationUser> _organizationUsers;

        public User()
        {
            _groupUsers = new List<GroupUser>();
            _organizationUsers = new List<OrganizationUser>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="password"></param>
        /// <param name="birthDay"></param>
        /// <param name="roleId"></param>
        public User(
            string code, 
            string firstName, 
            string lastName,
            string email, 
            string password, 
            DateTime? birthDay,
            int? roleId) : this()
        {
            Code = code;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            BirthDay = birthDay;
            RoleId = roleId;
        }

     

        public void Update(string firstName, string lastName, string email ,DateTime? birthDay)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
            Email = email;
        }

        public IReadOnlyCollection<GroupUser> GroupUsers => _groupUsers ??= new List<GroupUser>();
        public IReadOnlyCollection<OrganizationUser> OrganizationUsers => _organizationUsers ??= new List<OrganizationUser>();

        public void AddGroup(List<int> groupIds)
        {
            foreach (var item in groupIds)
            {
                _groupUsers.Add(new GroupUser(item));
            }
        }

        public void AddOrganization(List<int> organizationIds)
        {
            foreach (var item in organizationIds)
            {
                _organizationUsers.Add(new OrganizationUser(item));
            }
        }

        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDay { get; set; }
        public int? RoleId { get; set; }
    }
}
