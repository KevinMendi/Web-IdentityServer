using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IdentityServer4Host.IdentityConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4Host
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //~Add IdentityServer4 in the DI container and add it to the middleware pipeline
            services.AddIdentityServer() //~This will register IdentityServer4 in DI container
                .AddInMemoryClients(Clients.Get()) //~Hard coded Clients in Clients.Get() will be loaded into in-memory store
                .AddInMemoryIdentityResources(Resources.GetIdentityResources()) //~Hard coded Identity Resources in Resources.GetIdentityResources() will be loaded into in-memory store
                .AddInMemoryApiResources(Resources.GetApiResources()) //~Hard coded Api Resources in Resources.GetApiResources() will be loaded into in-memory store
                .AddInMemoryApiScopes(Scopes.GetApiScopes()) //~Hard coded Api Scopes in Scopes.GetApiScopes() will be loaded into in-memory store
                .AddTestUsers(Users.Get()) //~Hard coded Users in Users.Get() will be loaded as test user
                .AddDeveloperSigningCredential();//~IdentityServer4 will be configured to use demo signing certificate. IdentityServer4 uses certificate for signing credentials to verify that contents of the token have not been altered in transit.

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}
