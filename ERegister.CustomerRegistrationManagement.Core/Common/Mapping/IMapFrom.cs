
using AutoMapper;

namespace ERegister.CustomerRegistrationManagement.Core.Common.Mapping
{
    internal interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
