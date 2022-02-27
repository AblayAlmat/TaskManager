using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Services.TaskService;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            try
            {
                var tasks = _taskService.GetAllTaskViewModels();
                return View(tasks);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}