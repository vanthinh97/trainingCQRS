#region

using Microservices.Core.API.UnitTests;
using Microservices.Core.EventBus.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Moq;

#endregion

namespace Management.FunctionalTests
{
    public class CustomIntegrationTestStartup : IntegrationTestStartup
    {
        #region Methods

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            var mockEventBus = new Mock<IEventBus>();
            services.AddTransient(provider => mockEventBus.Object);
        }

        #endregion
    }
}