using ERegister.CustomerRegistrationManagement.Core.Features.Employee.Commands.AddEmployee;
using FluentAssertions;
using Xunit;

namespace ERegister.CustomerRegistrationManagement.Core.UnitTest.Feature.Employee.Commands.AddEmployee
{
    public class AddEmployeeValidatorTest
    {
        [Fact]
        public async Task AddEmployeeValidatorSuccess()
        {
            var command = new AddEmployeeCommand
            {
                Firstname = "Test",
                LastName = "Last Name",
                Address = "Address"
            };


            var addEmployeeValidator = new AddEmployeeValidator();
            var validationResult = await addEmployeeValidator.ValidateAsync(command);

            validationResult.Errors.Should().BeEmpty();
            validationResult.IsValid.Should().BeTrue();
        }

        [Fact]
        public async Task AddEmployeeValidatorErrorFirstNameRequired()
        {
            var command = new AddEmployeeCommand
            {
                LastName = "Last Name",
                Address = "Address"
            };


            var addEmployeeValidator = new AddEmployeeValidator();
            var validationResult = await addEmployeeValidator.ValidateAsync(command);

            validationResult.Errors.Should().HaveCountGreaterThan(1);
            validationResult.IsValid.Should().BeFalse();
        }
    }
}
