namespace ERegister.CustomerRegistrationManagement.Core.Domain.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key)
            :base($"{name} ({key} not found)")
        {
        }
    }
}
