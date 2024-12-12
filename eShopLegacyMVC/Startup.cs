using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace eShopLegacyMVC
{
    public partial class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure services here
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            // Configure the HTTP request pipeline here
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}