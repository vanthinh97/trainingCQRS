#region

using System.Reflection;
using Autofac;
using Management.Infrastructure;
using Microservices.Core.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Management.API
{
    /// <summary>
    ///     Register services to container and add middles to pipeline
    /// </summary>
    public sealed class Startup
    {
        #region Constructors

        /// <summary>
        ///     Initialize a instance with specified <see cref="IConfiguration" />
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration" /> of application</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Configuration of application
        /// </summary>
        public IConfiguration Configuration { get; }

        #endregion

        #region Methods

        /// <summary>
        ///     This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">
        ///     <see cref="IApplicationBuilder" />
        /// </param>
        public void Configure(IApplicationBuilder app)
        {
            app.UseIsolatedMicroserviceEnvironment();
        }

        /// <summary>
        ///     Phương thức này được gọi sau <see cref="ConfigureServices(IServiceCollection)" />
        /// </summary>
        /// <param name="builder">Autofac ContainerBuilder</param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddIsolatedCustomServices();
            builder.AddCustomDbContext<ApplicationDbContext>();
            // Đăng ký tất cả các mô đun Autofac
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        ///     This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">
        ///     <see cref="IServiceCollection" />
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIsolatedMicroserviceEnvironment();

            //Cấu hình server để upload file
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit         = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold    = int.MaxValue;
            });
        }

        #endregion
    }
}