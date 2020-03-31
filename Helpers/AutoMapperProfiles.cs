using AutoMapper;
using dotnetDating.api.DTO;
using dotnetDating.api.Models;

namespace dotnetDating.api.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
      CreateMap<User, UserForListDTO>().ForMember(destination => destination.PhotoURL, options => options.MapFrom(src => src.ProfilePicture.URL));
      CreateMap<User, UserForDetailedDTO>().ForMember(destination => destination.PhotoURL, options => options.MapFrom(src => src.ProfilePicture.URL));
      CreateMap<Quest, UserQuestListDTO>();
    }
  }
}