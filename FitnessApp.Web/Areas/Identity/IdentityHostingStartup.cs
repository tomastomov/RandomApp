using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(FitnessApp.Web.Areas.Identity.IdentityHostingStartup))]
namespace FitnessApp.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}