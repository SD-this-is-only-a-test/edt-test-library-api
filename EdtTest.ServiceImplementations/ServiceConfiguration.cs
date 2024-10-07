using EdtTest.Data;
using EdtTest.ServiceImplementations.Services;
using EdtTest.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EdtTest.ServiceImplementations
{
    public static class ServiceConfiguration
    {
        /// <summary>
        /// Configures service implementations and requirements for the application.
        /// </summary>
        /// <param name="services">The service collection to set up.</param>
        /// <param name="configuration">The configuration to use.</param>
        public static void ConfigureServiceImplementations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibraryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LibraryContextConnection"));
            });

            services.AddTransient<IBookLoansService, BookLoansService>();
            services.AddTransient<IBooksService, BooksService>();
            services.AddTransient<IMembersService, MembersService>();
        }
    }
}
