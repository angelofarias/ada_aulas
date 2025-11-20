using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using TodoApp.Repositories;

namespace TodoApp.Controllers
{
    
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository todoRepository;

        public TodoController(ITodoRepository todoRepository) {
            this.todoRepository = todoRepository;
        }

        [Route("/api/todo")] // GET /api/todo
        public IActionResult GetAllTodos()
        {   // retornar só os valores e não os indices
            return Ok(todoRepository.GetAll());
        }

        [Route("/api/todo/{id}")] // GET /api/todo/4
        public IActionResult GetTodoById(int id)
        {
            var todo = todoRepository.GetById(id);
            if (todo == null)
              return NotFound();

            return Ok(todo);
        }

        [HttpPost]
        [Route("/api/todo")] // POST /api/todo
        // Model Binding - o FromBody
        public IActionResult CreateTodo([FromBody] Todo todo)
        {
            if (TodoList.Tasks.ContainsKey(todo.Id))
                return Conflict(todo);

            TodoList.Tasks.Add(todo.Id, todo);

            return Created(); //asp.net vai mudar para um No Content.
        }

        [HttpPut]
        [Route("/api/todo/{id}")] // POST /api/todo
        // Model Binding
        public IActionResult CreateTodo([FromBody] Todo todo, int id)
        {
            if (id != todo.Id)
                return BadRequest();

            if (!TodoList.Tasks.ContainsKey(id))
                return NotFound();

            var varteste = TodoList.Tasks[id];

            varteste.Title = todo.Title;
            varteste.Description = todo.Description;
            varteste.IsCompleted = todo.IsCompleted;

            return Ok(varteste);
        }

        [HttpDelete]
        [Route("/api/todo/{id}")]
        public IActionResult Delete(int id)
        {
            if (!TodoList.Tasks.ContainsKey(id))
                return NotFound();

            TodoList.Tasks.Remove(id);

            return NoContent();
        }
    }
}