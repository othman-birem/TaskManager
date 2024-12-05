using Microsoft.AspNetCore.Mvc;
using TaskManager.Server.EntitiesManagement;
using TaskManager.Server.Models;

namespace TaskManager.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly TaskManagerContext _taskManagerContext;

        public CommentController(TaskManagerContext taskManagerContext)
        {
            _taskManagerContext = taskManagerContext;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Comment comment)
        {
            try
            {
                if (comment == null) { return BadRequest("Info cannot be null"); }

                if (await _taskManagerContext.Tasks.AnyAsync()) { return BadRequest("An unexpected error has occurred."); }

                comment.Id = Guid.NewGuid();
                _taskManagerContext.Comments.Add(comment);
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var comment = await _taskManagerContext.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound(new { Message = "Comment not found" });
            }

            _taskManagerContext.Comments.Remove(comment);
            await _taskManagerContext.SaveChangesAsync();

            return Ok(new { Message = "Comment deleted successfully" });
        }
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return _taskManagerContext.Comments.AsEnumerable();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> Get(Guid id)
        {
            var obj = await _taskManagerContext.Comments.FindAsync(id);

            if (obj == null) { return NotFound(); }

            return obj;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, Comment request)
        {
            if(!id.Equals(request.Id)) return BadRequest(new { Message = "The object ID does not match." });

            var obj = await _taskManagerContext.Comments.FindAsync(id);
            if(obj == null) { return NotFound(new { Message = "Object not found." }); }

            obj.Content = request.Content;

            await _taskManagerContext.SaveChangesAsync();
            return Ok(new { Message = "Object updated successfully." });
        }
    }
}
