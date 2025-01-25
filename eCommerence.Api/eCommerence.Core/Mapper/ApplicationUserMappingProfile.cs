using AutoMapper;
using eCommerence.Core.DTO;
using eCommerence.Core.Entities;
namespace eCommerence.Core.Mapper;

public class ApplicationUserMappingProfile: Profile
{
    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>().ForMember(dest => dest.UserID,
            opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Gender , opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
            .ForMember(dest => dest.Token, opt => opt.Ignore())
            .ForMember(dest => dest.Sucess, opt => opt.Ignore());
        ;
    }
}
