using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pioneers.Domain.Repositories;
using Pioneers.Infrastructure.Repositories;
using Pioneers.Infrastructure.Services;

namespace Pioneers.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<PioneersDbContext>(opt => opt.UseSqlServer(connectionString));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<CountryService>();
        services.AddScoped<CityService>();
        services.AddScoped<CustomerService>();
        return services;
    }
}
