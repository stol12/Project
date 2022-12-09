namespace NoLink.Extensions
{
    using AutoMapper;
    using NoLink.Data;
    using NoLink.Services.UserService.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<UserRegisterModel, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
