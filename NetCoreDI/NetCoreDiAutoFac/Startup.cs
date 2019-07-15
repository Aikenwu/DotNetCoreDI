using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetCoreDiAutoFac.Infrastructure;

namespace NetCoreDiAutoFac
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // 1.在 Startup.ConfigureServices 中配置容器并返回 IServiceProvider
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //2.Add Autofac containerBuild
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<DefaultModule>();
            containerBuilder.Populate(services);
            //3.build COntainer
            var container = containerBuilder.Build();
            //4.return provider
            return new AutofacServiceProvider(container);

            #region 批量
            //批量注册
            //var containerBuilder = new ContainerBuilder();

            //containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //    .Where(cc => cc.Name.EndsWith("Repository") |
            //                 cc.Name.EndsWith("Service"))
            //    .PublicOnly()
            //    .Where(cc => cc.IsClass)
            //    .AsImplementedInterfaces();
            //containerBuilder.Populate(services);

            //var container = containerBuilder.Build();
            //return new AutofacServiceProvider(container);
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
