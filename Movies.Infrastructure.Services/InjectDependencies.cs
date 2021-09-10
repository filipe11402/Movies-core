using Microsoft.Extensions.DependencyInjection;
using Movies.Domain.Services;
using Movies.Infrastructure.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
