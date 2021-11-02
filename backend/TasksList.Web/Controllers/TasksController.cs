using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksList.Web.Models;

namespace TasksList.Web.Controllers
{
    //[EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TasksListContext _context;

        public TasksController(TasksListContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskList>>> GetTaskLists()
        {
            return await _context.TaskLists.Where(c => c.IsRemoved == false).ToListAsync();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskList>> GetTaskList(int id)
        {
            var taskList = await _context.TaskLists.FindAsync(id);

            if (taskList == null)
            {
                return NotFound();
            }

            return taskList;
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskList(int id, TaskList taskList)
        {
            if (id != taskList.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTaskList", new { id = taskList.Id }, taskList); 
        }

        // POST: api/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskList>> PostTaskList(TaskListDto taskList)
        {
            var task = new TaskList();

            task.Text = taskList.Text;
            task.Day = taskList.Day;
            task.Reminder = taskList.Reminder;
            task.IsRemoved = false;

            _context.TaskLists.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskList", new { id = task.Id }, task);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskList(int id)
        {
            var taskList = await _context.TaskLists.FindAsync(id);
            if (taskList == null)
            {
                return NotFound();
            }

            taskList.IsRemoved = true;

            _context.Entry(taskList).State = EntityState.Modified;

            //_context.TaskLists.Remove(taskList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskListExists(int id)
        {
            return _context.TaskLists.Any(e => e.Id == id);
        }
    }
}
