using AutoMapper;
using dotnetDating.api.DTO;
using dotnetDating.api.Models;

namespace dotnetDating.api.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
      CreateMap<User, UserForListDTO>().ForMember(destination => destination.PhotoURL, options => options.MapFrom(src => src.Avatar.URL));
      CreateMap<User, UserForDetailedDTO>().ForMember(destination => destination.PhotoURL, options => options.MapFrom(src => src.Avatar.URL));
      CreateMap<Quest, UserQuestListDTO>();
      CreateMap<Quest, QuestDetailDTO>().ForMember(destination => destination.AssignedUser, options => options.MapFrom(src => src.AssignedUser.KnownAs));
    }
  }
}