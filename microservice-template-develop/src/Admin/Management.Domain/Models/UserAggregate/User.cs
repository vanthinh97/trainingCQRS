using Microservices.Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Domain.Models.UserAggregate
{
    public class User : Entity
    {
        /// <summary>
        /// Hàm khởi tạo của lớp <see cref="User"/>
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="birthDay"></param>
        public User(string firstName, string lastName, string email, string password, DateTime? birthDay)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            BirthDay = birthDay;
        }

        public User()
        {

        }

        public void Update(string firstName, string lastName,  DateTime? birthDay)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}
