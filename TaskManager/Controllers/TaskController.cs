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
                return NotFound();
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
                return NotFound();
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
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public IActionResult ChangeStatus([FromBody] StatusChangeViewModel model)
        {
            try
            {
                _taskService.ChangeStatus(model);
                return Ok(200);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            try
            {
                var model = _taskService.GetTaskEditViewModel(id);
                return View(model);
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaskEditViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _taskService.Edit(model);
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}