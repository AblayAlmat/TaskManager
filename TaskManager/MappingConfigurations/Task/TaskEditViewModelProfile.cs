using AutoMapper;
using TaskManager.ViewModels;

namespace TaskManager.MappingConfigurations.Task
{
    public class TaskEditViewModelProfile : Profile
    {
        public TaskEditViewModelProfile()
        {
            CreateMap<Models.Task, TaskEditViewModel>()
                .ForMember(dest => dest.Id, opt =>
                    opt.MapFrom(t => t.Id))
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(t => t.Name))
                .ForMember(dest => dest.Description, opt =>
                    opt.MapFrom(t => t.Description))
                .ForMember(dest => dest.Deadline, opt =>
                    opt.MapFrom(t => t.Deadline))
                .ForMember(dest => dest.Priority, opt =>
                    opt.MapFrom(t => t.Priority));
        }
    }
}