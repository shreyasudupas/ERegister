using ERegister.CustomerRegistrationManagement.Core.Common.Interfaces;
using ERegister.CustomerRegistrationManagement.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERegister.CustomerRegistrationManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ERegisterDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("ERegisterConnectionString"),
                    b=>b.MigrationsAssembly((typeof(ERegisterDbContext).Assembly.FullName))));

            services.AddScoped<IERegisterDbContext>(provider => provider.GetRequiredService<ERegisterDbContext>());

            return services;
        }
    }
}
