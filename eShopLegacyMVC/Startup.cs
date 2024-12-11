using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace eShopLegacyMVC
{
    public partial class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure services here
        }

        public void Configure(IApplicationBuilder app)
        {
            // Configure the HTTP request pipeline here
            ConfigureAuth(app);
        }
    }
}