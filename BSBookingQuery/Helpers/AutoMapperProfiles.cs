using AutoMapper;
using BSBookingQuery.Domain.DTOs;
using BSBookingQuery.Domain.Entities;

namespace BSBookingQuery.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<HotelDto, Hotel>().ForMember(x => x.HotelId, opt => opt.Ignore()).ReverseMap();
            CreateMap<LabelDto, Label>().ReverseMap();
            CreateMap<RegisterDto, User>().ReverseMap();
            CreateMap<RegisterDto, UserDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CommentDto, CommentHistory>().ReverseMap();
        }
    }
}
