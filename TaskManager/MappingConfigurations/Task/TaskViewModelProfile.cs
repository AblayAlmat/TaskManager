using AutoMapper;
using TaskManager.ViewModels;

namespace TaskManager.MappingConfigurations.Task
{
    public class TaskViewModelProfile : Profile
    {
        public TaskViewModelProfile()
        {
            CreateMap<Models.Task, TaskViewModel>()
                .ForMember(dest => dest.Id, opt =>
                    opt.MapFrom(t => t.Id))
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(t => t.Name))
                .ForMember(dest => dest.Description, opt =>
                    opt.MapFrom(t => t.Description))
                .ForMember(dest => dest.Priority, opt =>
                    opt.MapFrom(t => t.Priority))
                .ForMember(dest => dest.Deadline, opt =>
                    opt.MapFrom(t => t.Deadline))
                .ForMember(dest => dest.CreationDate, opt =>
                    opt.MapFrom(t => t.CreationDate))
                .ForMember(dest => dest.FinishingDate, opt =>
                    opt.MapFrom(t => t.FinishingDate))
                .ForMember(dest => dest.CreatorName, opt =>
                    opt.MapFrom(t => t.Creator.UserName))
                .ForMember(dest => dest.ExecutorName, opt =>
                    opt.MapFrom(t => t.Executor.UserName))
                .ForMember(dest => dest.Status, opt =>
                    opt.MapFrom(t => t.Status));
        }
    }
}