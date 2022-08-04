using ContosoUniversity.DAL.IConfiguration;
using ContosoUniversity.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContosoUniversity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults.AuthenticationScheme;

            })
            .AddCookie() //~Add cookie authentication. On successful authentication from IdentityServer4 a domain cookie will be issued and set in the HTTPS request for user details/claims
            .AddOpenIdConnect(options => //~Adds OpenID connect authentication
            {
                options.Authority = $"https://localhost:44366"; //~Authority URL is the URL of our Identity Server
                options.ClientId = "ContosoUniversityMVCApp";
                options.RequireHttpsMetadata = false;
                options.Scope.Add("profile");
                options.Scope.Add("openid");
                options.Scope.Add("role");
                options.ResponseType = "id_token";
                options.SaveTokens = true; //~Specifies whether access and refresh token should be saved in authentications properties or not
            });

            services.AddControllersWithViews();

            //Add the Unit of Work to the DI container
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}")
                .RequireAuthorization();
            });
        }
    }
}
