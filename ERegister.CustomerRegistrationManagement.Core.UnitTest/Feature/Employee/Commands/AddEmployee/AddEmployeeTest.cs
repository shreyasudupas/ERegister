using ERegister.CustomerRegistrationManagement.Core.Features.Employee.Commands.AddEmployee;
using ERegister.CustomerRegistrationManagement.Core.UnitTest.Mocks;
using FluentAssertions;
using Moq;
using Xunit;

namespace ERegister.CustomerRegistrationManagement.Core.UnitTest.Feature.Employee.Commands.AddEmployee
{
    public class AddEmployeeTest : BaseDbContext
    {
        public AddEmployeeTest()
        {
        }

        [Fact]
        public async Task AddEmployeeSuccessfully()
        {
            var handler = new AddEmployeeCommandHandler(_dbContext);

            var command = new AddEmployeeCommand
            {
                Firstname = "Shreyas",
                LastName = "Udupa",
                Middlename = "S",
                Address = "Sample address",
                City = "sample city",
                ApartmentNumber = "21",
                Email = "test@xyz@ghh.com",
                PayPerHour = 20.2F,
                PhoneNumber = "(029)112222",
                State = "sample state",
                Zipcode = 82827
            };

            var expected = new AddEmployeeResponse();

            var actualResult = await handler.Handle(command,It.IsAny<CancellationToken>());

            actualResult.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task AddEmployeeShouldThrowErrorWhenFirstNameIsEmpty()
        {
            var handler = new AddEmployeeCommandHandler(_dbContext);

            var command = new AddEmployeeCommand
            {
                Firstname = "",
                LastName = "Udupa",
                Middlename = "S",
                Address = "Sample address",
                City = "sample city",
                ApartmentNumber = "21",
                Email = "test@xyz@ghh.com",
                PayPerHour = 20.2F,
                PhoneNumber = "(029)112222",
                State = "sample state",
                Zipcode = 82827
            };

            var expected = new AddEmployeeResponse
            {
                Success = false,
                ValidationError = new List<string>
                {
                    "Firstname is required"
                }
            };

            var actualResult = await handler.Handle(command, It.IsAny<CancellationToken>());

            actualResult.Should().BeEquivalentTo(expected);
        }
    }
}
