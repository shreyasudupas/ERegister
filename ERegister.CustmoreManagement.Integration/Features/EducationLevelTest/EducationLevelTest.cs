using ERegister.CustmoreManagement.Integration.Build;
using ERegister.CustomerRegistrationManagement.Core.Domain.Entities;
using ERegister.CustomerRegistrationManagement.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ERegister.CustmoreManagement.Integration.Features.EducationLevelTest
{
    public class EducationLevelTest : IClassFixture<ERegisterWebFactory<Program>>
    {
        public HttpClient _client;

        private readonly ERegisterWebFactory<Program> _factory;

        public EducationLevelTest(ERegisterWebFactory<Program> factory)
        {

            _client = factory.CreateDefaultClient();

            var scope = factory.Services.CreateScope();
            var provider = scope.ServiceProvider;

            var fakeDbContext = provider.GetRequiredService<ERegisterDbContext>();
            fakeDbContext.Database.EnsureCreated();

            SeedData(fakeDbContext);

            fakeDbContext.SaveChangesAsync(It.IsAny<CancellationToken>()).GetAwaiter().GetResult();

            _factory = factory;
        }

        private void SeedData(ERegisterDbContext fakeDbContext)
        {
            fakeDbContext.EducationLevels.AddRange(new List<EducationLevel>
            {
                new EducationLevel{ Id = 1 , Name = "High School" },
                new EducationLevel { Id = 2 , Name = "Secondary High School" },
                new EducationLevel { Id = 3, Name = "BE" }
            });
        }

        [Fact]
        public async Task GetEducationLevelApi_EnsureSuccessStatusCode()
        {
            var response = await _client.GetAsync("/api/EducationLevel");

            response.EnsureSuccessStatusCode();
        }
    }
}
