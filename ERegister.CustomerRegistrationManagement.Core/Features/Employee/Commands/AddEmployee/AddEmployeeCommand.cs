using ERegister.CustomerRegistrationManagement.Core.Common.Interfaces;
using MediatR;

namespace ERegister.CustomerRegistrationManagement.Core.Features.Employee.Commands.AddEmployee
{
    public class AddEmployeeCommand : IRequest<AddEmployeeResponse>
    {
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string Email { get; set; }
        public float PayPerHour { get; set; }
    }

    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, AddEmployeeResponse>
    {
        private readonly IERegisterDbContext _context;

        public AddEmployeeCommandHandler(IERegisterDbContext context)
        {
            _context = context;
        }

        public async Task<AddEmployeeResponse> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var addEmployeeResponse = new AddEmployeeResponse();

            var addEmployeeValidator = new AddEmployeeValidator();
            var validationrResult = await addEmployeeValidator.ValidateAsync(request);

            if(validationrResult.Errors.Count > 0)
            {
                addEmployeeResponse.Success = false;
                addEmployeeResponse.ValidationError = new List<string>();
                validationrResult.Errors.ForEach(error => addEmployeeResponse.ValidationError.Add(error.ErrorMessage));
            }

            if(addEmployeeResponse.Success)
            {
                _context.Employees.Add(new Domain.Entities.Employee
                {
                    Firstname = request.Firstname,
                    Middlename = request.Middlename,
                    LastName = request.LastName,
                    Phonenumber = request.PhoneNumber,
                    Address = request.Address,
                    ApartmentNumber = request.ApartmentNumber,
                    City = request.City,
                    State = request.State,
                    Zipcode = request.Zipcode,
                    Email = request.Email,
                    PayPerHour = request.PayPerHour
                });

                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return addEmployeeResponse;

        }
    }
}
