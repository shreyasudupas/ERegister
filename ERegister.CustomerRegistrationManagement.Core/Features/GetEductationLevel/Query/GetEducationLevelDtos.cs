using AutoMapper;
using ERegister.CustomerRegistrationManagement.Core.Common.Mapping;
using ERegister.CustomerRegistrationManagement.Core.Domain.Entities;

namespace ERegister.CustomerRegistrationManagement.Core.Features.GetEductationLevel.Query
{
    public class GetEducationLevelDtos : IMapFrom<EducationLevel>
    {
        public int Id { get; set; }
        public string LevelName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EducationLevel, GetEducationLevelDtos>()
                .ForMember(dest => dest.LevelName, act => act.MapFrom(src => src.Name));
        }
    }
}
