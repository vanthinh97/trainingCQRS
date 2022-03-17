#region

using Management.Domain.Models.GroupAggregate;
using Management.Domain.Models.GroupUserAggregate;
using Management.Domain.Models.OrganizationAggregate;
using Management.Domain.Models.OrganizationUserAggregate;
using Management.Domain.Models.UserAggregate;
using Management.Infrastructure.EntityConfigurations;
using MediatR;
using Microservices.Core.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

#endregion

namespace Management.Infrastructure
{
    public class ApplicationDbContext : DbContextCore
    {
        #region Constructors

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator) : base(options, mediator)
        {
        }

        #endregion

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationUser> OrganizationUsers { get; set; }

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GroupEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GroupUserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationUserEntityTypeConfiguration());
        }

        #endregion

    }
}