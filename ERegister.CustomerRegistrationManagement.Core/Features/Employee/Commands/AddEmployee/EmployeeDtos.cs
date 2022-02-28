using AutoMapper;
using ERegister.CustomerRegistrationManagement.Core.Common.Mapping;

namespace ERegister.CustomerRegistrationManagement.Core.Features.Employee.Commands.AddEmployee
{
    public class EmployeeDtos : IMapFrom<Domain.Entities.Employee>
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string Email { get; set; }
        public float PayPerHour { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Employee, EmployeeDtos>()
                .ForMember(dest => dest.EmployeeId, act => act.MapFrom(src => src.Id))
                .ForMember(dest=>dest.FirstName,act=>act.MapFrom(src=>src.Firstname))
                .ForMember(dest => dest.MiddleName, act => act.MapFrom(src => src.Middlename))
                .ForMember(dest => dest.PhoneNumber, act => act.MapFrom(src => src.Phonenumber))
                .ReverseMap();
        }
    }
}
