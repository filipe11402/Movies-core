using Microsoft.Extensions.DependencyInjection;
using Movies.Domain.Services;
using Movies.Infrastructure.Services.Services;

namespace Movies.Infrastructure.Services
{
    public static class InjectDependencies
    {
        public static void AddServices(this IServiceCollection services) 
        {
            services.AddScoped<IMovieService, MovieService>();
        }
    }
}
