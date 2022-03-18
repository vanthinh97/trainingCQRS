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
        /// <summary>
        /// Hàm khởi tạo của lớp <see cref="User"/>
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="birthDay"></param>
        public User(string firstName, string lastName, string email, string password, DateTime? birthDay) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            BirthDay = birthDay;
        }

        public User()
        {
            _groupUsers = new List<GroupUser>();
            _organizationUsers = new List<OrganizationUser>();
        }

        public void Update(string firstName, string lastName,  DateTime? birthDay)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
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

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDay { get; set; }

   
    }
}
