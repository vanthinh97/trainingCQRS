using Management.Domain.Models.GroupUserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Infrastructure.EntityConfigurations
{
    public class GroupUserEntityTypeConfiguration : IEntityTypeConfiguration<GroupUser>
    {
        public void Configure(EntityTypeBuilder<GroupUser> builder)
        {
            builder.ToTable("GroupUsers");
            builder.HasKey(x => x.Id);
        }
    }
}
