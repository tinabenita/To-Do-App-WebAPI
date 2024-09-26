using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList2.Api.Controllers
{
    [Route("ToDoList/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
         static List<ToDoList>  taskList = new List<ToDoList>
            {
                new ToDoList
                {
                    TaskId = 101,
                    TaskName = "Complete assignment",
                    TaskDate = new DateOnly(2024, 9, 27),
                    IsCompleted = true
                },
                new ToDoList
                {
                    TaskId = 102,
                    TaskName = "Buy a red dress",
                    TaskDate = new DateOnly(2024, 9, 28),
                    IsCompleted = false
                },
                new ToDoList
                {
                    TaskId = 103,
                    TaskName = "Write a poem",
                    TaskDate = new DateOnly(2024, 9, 30),
                    IsCompleted = false
                },
                new ToDoList
                {
                    TaskId = 104,
                    TaskName = "Plant a sapling",
                    TaskDate = new DateOnly(2024, 10, 8),
                    IsCompleted = true
                }

          };



        // GET: api/<ToDoListController>
        [HttpGet("ViewAllTasks")]
        public IActionResult Get()
        {
            
            return Ok(taskList);
        }

        // GET api/<ToDoListController>/5
        [HttpGet("ViewTask/{id}")]
        public IActionResult Get(int id)
        {
            
            var task = taskList.FirstOrDefault(t => t.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        // POST api/<ToDoListController>
        [HttpPost("CreateTask")]
        public IActionResult CreateTask([FromBody] ToDoList myTask)
        {

            var LastId = taskList.Last();

            myTask.TaskId = LastId.TaskId + 1;

            taskList.Add(myTask);

            return Ok(taskList);
        }

        // PUT api/<ToDoListController>/UpdateTask/5
        [HttpPut("UpdateTask/{id}")]
        public IActionResult Put(int id, [FromBody] string taskvalue)
        {
            var taskToUpdate = new List<ToDoList>
            {
                new ToDoList
                {
                    TaskId = 105,
                    TaskName = "Fill tank",
                    TaskDate = new DateOnly(2024, 10, 15),
                    IsCompleted = false
                }
            };

            if (id <= 0 || id > taskToUpdate.Count)
            {
                return BadRequest("Operation not performed");
            }

            var task = taskToUpdate.FirstOrDefault(t => t.TaskId == id);
            if (task == null)
            {
                return NotFound("Task not found");
            }

            task.TaskName = taskvalue;
            return Ok(taskToUpdate);
        }

        // DELETE api/<ToDoListController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var taskToDeleteDetails = new List<ToDoList>
            {
                new ToDoList
                {
                    TaskId = 105,
                    TaskName = "Fill tank",
                    TaskDate = new DateOnly(2024, 10, 15),
                    IsCompleted = false
                }
            };

            var taskToDelete = taskToDeleteDetails.FirstOrDefault(t => t.TaskId == id);
            
            if (taskToDelete == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }

            taskToDeleteDetails.Remove(taskToDelete);
            return Ok(taskToDeleteDetails);
        }
    }
}
