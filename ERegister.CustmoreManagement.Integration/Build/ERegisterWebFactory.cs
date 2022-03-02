using ERegister.CustomerRegistrationManagement.Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace ERegister.CustmoreManagement.Integration.Build
{
    public class ERegisterWebFactory<TClass> : WebApplicationFactory<TClass> where TClass : class
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<ERegisterDbContext>));
                services.AddDbContext<ERegisterDbContext>(options =>
                    options.UseInMemoryDatabase("Tetsing",root));
            });

            return base.CreateHost(builder);
        }
    }
}
