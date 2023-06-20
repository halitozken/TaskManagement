using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public TaskController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            try
            {
                var tasks = _manager.TaskService.GetAllTasks(false);
                return Ok(tasks);
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneTask([FromRoute(Name = "id")] int id)
        {
            try
            {
                var task = _manager.TaskService.GetOneTaskById(id, false);

                if (task is null)
                    return NotFound();

                return Ok(task);
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateOneTask([FromBody] TaskModel task)
        {
            try
            {
                if (task is null)
                    return BadRequest();

                _manager.TaskService.CreateOneTask(task);
                return StatusCode(201, task);
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneTask([FromRoute(Name = "id")] int id, [FromBody] TaskModel task)
        {
            try
            {
                if (task is null)
                    return BadRequest();

                _manager.TaskService.UpdateOneTask(id, task, true);

                return NoContent();
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneTask([FromRoute(Name = "id")] int id)
        {
            try
            {
                _manager.TaskService.DeleteOneTask(id, false);
                return NoContent();
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneTask([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<TaskModel> taskPatch)
        {
            try
            {
                var entity = _manager.TaskService.GetOneTaskById(id, true);

                if (entity is null)
                    return NotFound();

                taskPatch.ApplyTo(entity);
                _manager.TaskService.UpdateOneTask(id, entity, true);

                return NoContent();
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}