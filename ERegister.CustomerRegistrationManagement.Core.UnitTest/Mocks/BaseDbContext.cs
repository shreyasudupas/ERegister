using AutoMapper;
using ERegister.CustomerRegistrationManagement.Core.Common.Interfaces;
using ERegister.CustomerRegistrationManagement.Core.Common.Mapping;
using ERegister.CustomerRegistrationManagement.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ERegister.CustomerRegistrationManagement.Core.UnitTest.Mocks
{
    public class BaseDbContext
    {
        public IERegisterDbContext _dbContext;
        public IMapper _mapper;

        public BaseDbContext()
        {
            var options = new DbContextOptionsBuilder<ERegisterDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _dbContext = new ERegisterDbContext(options);


            var config = new MapperConfiguration(config =>
                config.AddProfile<MappingProfile>());

            _mapper = config.CreateMapper();
        }
    }
}
