using Microsoft.AspNetCore.Mvc;
using ApiChallenger.Context;
using ApiChallenger.Enum;

namespace ApiChallenger.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly OrganizerContext _context;

        public TaskController(OrganizerContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var tasks = _context.Tasks.ToList();
            return Ok(tasks);
        }

        [HttpGet("GetByTitle")]
        public IActionResult GetByTitle(string title)
        {
            var tasks = _context.Tasks.Where(x => x.Title == title);

            return Ok(tasks);
        }

        [HttpGet("GetByDate")]
        public IActionResult GetByDate(DateTime date)
        {
            var task = _context.Tasks.Where(x => x.Date.Date == date.Date);

            return Ok(task);
        }

        [HttpGet("GetByStatus")]
        public IActionResult GetByStatus(EnumTaskStatus status)
        {
            var tasks = _context.Tasks.Where(x => x.Status == status);
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult Create(ApiChallenger.Models.Task task)
        {
            if (task.Date == DateTime.MinValue)
            {
                return BadRequest(new { Error = "A data da tarefa não pode ser vazia" });
            }

            _context.Tasks.Add(task);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ApiChallenger.Models.Task task)
        {
            var taskDataBase = _context.Tasks.Find(id);

            if (taskDataBase == null)
            {
                return NotFound();
            }

            if (task.Date == DateTime.MinValue)
            {
                return BadRequest(new { Error = "A data da tarefa não pode ser vazia" });
            }

            taskDataBase.Title = task.Title;
            taskDataBase.Description = task.Description;
            taskDataBase.Date = task.Date;
            taskDataBase.Status = task.Status;
            _context.SaveChanges();

            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var taskDataBase = _context.Tasks.Find(id);

            if (taskDataBase == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(taskDataBase);
            _context.SaveChanges();

            return NoContent();
        }

    }
}