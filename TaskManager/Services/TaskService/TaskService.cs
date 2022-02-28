using System.Collections.Generic;
using AutoMapper;
using TaskManager.Repositories.TaskRepository;
using TaskManager.ViewModels;

namespace TaskManager.Services.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(
            ITaskRepository taskRepository, 
            IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public List<TaskViewModel> GetAllTaskViewModels()
        {
            var tasks = _taskRepository.GetAll();
            return _mapper.Map<List<TaskViewModel>>(tasks);
        }
    }
}