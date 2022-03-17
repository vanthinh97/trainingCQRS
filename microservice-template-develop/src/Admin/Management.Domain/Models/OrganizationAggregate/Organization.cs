using Management.Domain.Models.OrganizationUserAggregate;
using Microservices.Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Domain.Models.OrganizationAggregate
{
    public class Organization : Entity
    {
        private List<OrganizationUser> _organizationUsers;
        public Organization()
        {
            _organizationUsers = new List<OrganizationUser>();
        }
        /// <summary>
        /// Ham khoi tao cua <see cref="Organization"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public Organization(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public IReadOnlyCollection<OrganizationUser> OrganizationUsers => _organizationUsers ??= new List<OrganizationUser>();

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
