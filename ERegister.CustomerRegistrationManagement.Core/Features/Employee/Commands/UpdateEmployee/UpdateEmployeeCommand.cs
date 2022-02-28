using AutoMapper;
using ERegister.CustomerRegistrationManagement.Core.Common.Interfaces;
using ERegister.CustomerRegistrationManagement.Core.Domain.Exceptions;
using ERegister.CustomerRegistrationManagement.Core.Features.Employee.Commands.AddEmployee;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ERegister.CustomerRegistrationManagement.Core.Features.Employee.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<UpdateEmployeeResponse>
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string Address { get; set; }
    }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, UpdateEmployeeResponse>
    {
        private readonly IERegisterDbContext _context;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IERegisterDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateEmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var updateEmployeeResponse = new UpdateEmployeeResponse();

            var updateEmployeeValidator = new UpdateEmployeeCommandValidator();
            var validationResult = await updateEmployeeValidator.ValidateAsync(request, cancellationToken);

            if(validationResult.Errors.Count > 0)
            {
                updateEmployeeResponse.Success = false;
                updateEmployeeResponse.ValidationError = new List<string>();
                validationResult.Errors.ForEach(error => updateEmployeeResponse.ValidationError.Add(error.ErrorMessage));
            }

            if(updateEmployeeResponse.Success)
            {
                var employee = await _context.Employees.Where(e => e.Id == request.EmployeeId).FirstOrDefaultAsync();

                if(employee == null)
                {
                    throw new NotFoundException(nameof(UpdateEmployeeCommand), request.EmployeeId);
                }

                employee.Firstname = request.FirstName;
                employee.Address = request.Address;

                await _context.SaveChangesAsync(cancellationToken);

                updateEmployeeResponse.Employee = _mapper.Map<EmployeeDtos>(employee);
            }

            return updateEmployeeResponse;
        }
    }
}
