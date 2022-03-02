using AutoMapper;
using TaskManager.MappingConfigurations.Resolvers;
using TaskManager.ViewModels;

namespace TaskManager.MappingConfigurations.Task
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskCreateViewModel, Models.Task>()
                .ForMember(dest => dest.Deadline, opt =>
                    opt.MapFrom(tcvm => tcvm.Deadline))
                .ForMember(dest => dest.Description, opt =>
                    opt.MapFrom(tcvm => tcvm.Description))
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(tcvm => tcvm.Name))
                .ForMember(dest => dest.Priority, opt =>
                    opt.MapFrom(tcvm => tcvm.Priority))
                .ForMember(dest => dest.CreationDate, opt =>
                    opt.MapFrom(tcvm => tcvm.CreationDate))
                .ForMember(dest => dest.Creator, opt =>
                    opt.MapFrom<GetUserResolver>())
                .ForMember(dest => dest.Status, opt => 
                    opt.MapFrom(tcvm => tcvm.Status));
        }
    }
}