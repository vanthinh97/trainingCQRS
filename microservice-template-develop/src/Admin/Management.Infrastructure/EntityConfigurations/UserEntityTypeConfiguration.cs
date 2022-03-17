using Management.Domain.Models.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Management.Infrastructure.EntityConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.BirthDay).IsRequired(false);

            builder.Metadata.FindNavigation(nameof(User.GroupUsers))?.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(User.OrganizationUsers))?.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
