﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Infrastructure.Context;

namespace Movies.Infrastructure
{
    public static class InjectDependencies
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("MovieConnection"), b => b.MigrationsAssembly("Movies.Infrastructure"));
            });
        }
    }
}
