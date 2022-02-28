using ERegister.CustomerRegistrationManagement.Core.Domain.Exceptions;
using ERegister.CustomerRegistrationManagement.Core.Features.Employee.Commands.AddEmployee;
using ERegister.CustomerRegistrationManagement.Core.Features.Employee.Commands.UpdateEmployee;
using ERegister.CustomerRegistrationManagement.Core.UnitTest.Mocks;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ERegister.CustomerRegistrationManagement.Core.UnitTest.Feature.Employee.Commands.UpdateEmployee
{
    public class EmployeeUpdateTest : BaseDbContext
    {
        public EmployeeUpdateTest()
        {
            _dbContext.Employees.Add(new Domain.Entities.Employee
            {
                Firstname = "Shreyas",
                LastName = "Udupa",
                Middlename = "S",
                Address = "Sample address",
                City = "sample city",
                ApartmentNumber = "21",
                Email = "test@xyz@ghh.com",
                PayPerHour = 20.2F,
                Phonenumber = "(029)112222",
                State = "sample state",
                Zipcode = 82827
            });

            _dbContext.SaveChangesAsync(It.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task UpdateEmployeeSuccessfully()
        {
            var handler = new UpdateEmployeeCommandHandler(_dbContext,_mapper);

            var command = new UpdateEmployeeCommand
            {
                EmployeeId = 1,
                FirstName = "Test",
                Address = "Sample address 1"
            };

            var expected = new UpdateEmployeeResponse
            {
                Success = true,
                Employee = new EmployeeDtos
                {
                    EmployeeId = 1,
                    FirstName = "Test",
                    LastName = "Udupa",
                    MiddleName = "S",
                    Address = "Sample address 1",
                    City = "sample city",
                    ApartmentNumber = "21",
                    Email = "test@xyz@ghh.com",
                    PayPerHour = 20.2F,
                    PhoneNumber = "(029)112222",
                    State = "sample state",
                    Zipcode = 82827
                }
            };

            var actual = await handler.Handle(command,It.IsAny<CancellationToken>());

            actual.Employee.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void UpdateEmployeeShouldThrowNotFoundException(int EmployeeId)
        {
            var handler = new UpdateEmployeeCommandHandler(_dbContext, _mapper);

            var command = new UpdateEmployeeCommand
            {
                EmployeeId = EmployeeId,
                FirstName = "Test",
                Address = "Sample address 1"
            };

            Action act = () => handler.Handle(command, It.IsAny<CancellationToken>()).GetAwaiter().GetResult();

            act.Should().Throw<NotFoundException>();
        }
    }
}
