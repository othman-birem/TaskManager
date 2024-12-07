using Microsoft.AspNetCore.Mvc;
using TaskManager.Server.EntitiesManagement;
using Task = TaskManager.Server.Models.Task;

namespace TaskManager.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskManagerContext _taskManagerContext;

        public TaskController(TaskManagerContext taskManagerContext)
        {
            _taskManagerContext = taskManagerContext;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Task _task)
        {
            try
            {
                if (_task == null) { return BadRequest("Info cannot be null"); }

                if (await _taskManagerContext.Tasks.AnyAsync()) { return BadRequest("An unexpected error has occurred."); }

                _task.Id = Guid.NewGuid();
                _taskManagerContext.Tasks.Add(_task);
                await _taskManagerContext.SaveChangesAsync();

                return Ok("Task has been added successfully.");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"An error occurred while saving the object: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }
        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return _taskManagerContext.Tasks.AsEnumerable();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Task>> Get(Guid id)
        {
            var obj = await _taskManagerContext.Tasks.FindAsync(id);

            if(obj == null) { return NotFound(); }

            return obj;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var task = await _taskManagerContext.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound(new { Message = "Task not found" });
            }

            _taskManagerContext.Tasks.Remove(task);
            await _taskManagerContext.SaveChangesAsync();

            return Ok(new { Message = "Task deleted successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, Task request)
        {
            if (!id.Equals(request.Id))
            {
                return BadRequest(new { Message = "The object ID does not match." });
            }

            var task = await _taskManagerContext.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound(new { Message = "Object not found." });
            }

            task.CategoryId = request.CategoryId;
            task.Name = request.Name;
            task.Description = request.Description;
            task.DueDate = request.DueDate;
            task.Status = request.Status;

            await _taskManagerContext.SaveChangesAsync();

            return Ok(new { Message = "Object updated successfully." });
        }
    }
}
