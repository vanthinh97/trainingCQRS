#region


#endregion

using Autofac;
using Management.API.Helper;
using Management.Domain.Models.AccountAggregate;
using Management.Domain.Models.GroupAggregate;
using Management.Domain.Models.GroupUserAggregate;
using Management.Domain.Models.OrganizationAggregate;
using Management.Domain.Models.OrganizationUserAggregate;
using Management.Domain.Models.UserAggregate;
using Management.Domain.Queries.UserAggregate;
using Management.Infrastructure.Queries;
using Management.Infrastructure.Repositories;

namespace Management.API.AutofacModules
{
    /// <summary>
    ///     Definces a contract for a collection service's descriptors
    /// </summary>
    public class ApplicationModule : Module
    {
        #region Methods

        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GroupRepository>().As<IGroupRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GroupUserRepository>().As<IGroupUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrganizationRepository>().As<IOrganizationRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrganizationUserRepository>().As<IOrganizationUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AccountRepository>().As<IAccountRepository>().InstancePerLifetimeScope();


            builder.RegisterType<CommonHelper>().As<ICommonHelper>().InstancePerLifetimeScope();
            builder.RegisterType<UserQueries>().As<IUserQueries>().InstancePerLifetimeScope();
        }

        #endregion
    }
}