using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Services.TaskService;
using TaskManager.ViewModels;

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

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskCreateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _taskService.CreateTask(model);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        [HttpGet]
        [Authorize()]
        public IActionResult GetDetails(string id)
        {
            try
            {
                var details = _taskService.GetDetails(id);
                return View(details);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}