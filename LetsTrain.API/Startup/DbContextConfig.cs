using LetsTrain.API.Data;
using Microsoft.EntityFrameworkCore;

namespace LetsTrain.API.Startup
{
    public static class DbContextConfig
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LetsTrainDb>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DevConnection")));
        }
    }
}
