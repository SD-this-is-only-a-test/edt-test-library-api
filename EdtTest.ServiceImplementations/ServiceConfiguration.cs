using EdtTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EdtTest.ServiceImplementations
{
    /// <summary>
    /// This will contain an extension method or methods for setting up all of our service implementations.
    /// </summary>
    public static class ServiceConfiguration
    {
        public static void ConfigureServiceImplementations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibraryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LibraryContextConnection"));
            });
        }
    }
}
