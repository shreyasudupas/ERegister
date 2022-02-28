
namespace ERegister.CustomerRegistrationManagement.Core.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string LastName { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string Email { get; set; }
        public float PayPerHour { get; set; }
    }
}
