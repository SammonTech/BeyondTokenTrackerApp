using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.DependencyInjection
{
    public static class ContextInjector
    {
        public static void ConfigureEntityFramework(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BeyondTokenTrackerContext>(options => options.UseSqlServer(connectionString, sqlOptions => sqlOptions.EnableRetryOnFailure()));
        }
    }
}
