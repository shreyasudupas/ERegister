using ERegister.CustomerRegistrationManagement.Core.Common.Interfaces;
using ERegister.CustomerRegistrationManagement.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ERegister.CustomerRegistrationManagement.Infrastructure.Persistance
{
    public class ERegisterDbContext : DbContext, IERegisterDbContext
    {
        public ERegisterDbContext(DbContextOptions<ERegisterDbContext> options)
            :base(options)
        { 
        }

        //Start here
        public DbSet<EducationLevel> EducationLevels => Set<EducationLevel>();
        public DbSet<Employee> Employees => Set<Employee>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return result;
        }
    }
}
