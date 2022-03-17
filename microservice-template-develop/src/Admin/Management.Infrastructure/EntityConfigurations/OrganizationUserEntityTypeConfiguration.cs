using Management.Domain.Models.OrganizationUserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Infrastructure.EntityConfigurations
{
    public class OrganizationUserEntityTypeConfiguration : IEntityTypeConfiguration<OrganizationUser>
    {
        public void Configure(EntityTypeBuilder<OrganizationUser> builder)
        {
            builder.ToTable("OrganizationUsers");
            builder.HasKey(x => x.Id);
        }
    }
}
