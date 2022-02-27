using AutoMapper;
using TaskManager.Models;
using TaskManager.ViewModels;

namespace TaskManager.MappingConfigurations.Account
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterViewModel, User>()
                .ForMember(dest => dest.Email, opt =>
                    opt.MapFrom(rvm => rvm.Email))
                .ForMember(dest => dest.UserName, opt =>
                    opt.MapFrom(rvm => rvm.UserName));
        }
    }
}