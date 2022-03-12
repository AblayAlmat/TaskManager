using System;
using System.Collections.Generic;
using AutoMapper;
using TaskManager.Enums;
using TaskManager.Models;
using TaskManager.Repositories.TaskRepository;
using TaskManager.Repositories.UserRepository;
using TaskManager.ViewModels;

namespace TaskManager.Services.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public TaskService(
            ITaskRepository taskRepository, 
            IMapper mapper, 
            IUserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public List<TaskViewModel> GetAllTaskViewModels()
        {
            var tasks = _taskRepository.GetAll();
            return _mapper.Map<List<TaskViewModel>>(tasks);
        }

        public void CreateTask(TaskCreateViewModel model)
        {
            var task = _mapper.Map<Task>(model);
            _taskRepository.Add(task);
            _taskRepository.Save();
        }
        
        public TaskViewModel GetDetails(string id)
        {
            var task = _taskRepository.GetById(id);
            return _mapper.Map<TaskViewModel>(task);
        }

        public void ChangeStatus(StatusChangeViewModel model)
        {
            var task = _taskRepository.GetById(model.TaskId);
            var user = _userRepository.GetById(model.ExecutorId);
            task.Executor = user;
            task.Status = (Status) ((int) model.CurrentStatus + 1);
            if (task.Status == Status.Closed)
            {
                task.FinishingDate = DateTime.Now;
            }
            _taskRepository.Save();
        }

        public TaskEditViewModel GetTaskEditViewModel(string id)
        {
            var task = _taskRepository.GetById(id);
            return _mapper.Map<TaskEditViewModel>(task);
        }

        public void Edit(TaskEditViewModel model)
        {
            var task = _taskRepository.GetById(model.Id);
            task.Name = model.Name;
            task.Description = model.Description;
            task.Priority = model.Priority;
            task.Deadline = model.Deadline;
            _taskRepository.Save();
        }
    }
}