using ERegister.CustomerRegistrationManagement.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERegister.CustomerRegistrationManagement.Core.Common.Interfaces
{
    public interface IERegisterDbContext
    {
        DbSet<EducationLevel> EducationLevels { get; }

        DbSet<Employee> Employees { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
