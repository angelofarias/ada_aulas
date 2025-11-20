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
        // Model Binding
        public IActionResult CreateTodo([FromBody] Todo todo)
        {
            var existingTodo = todoRepository.GetById(todo.Id);
            if (existingTodo != null)
                return Conflict(existingTodo);

            todo = todoRepository.Create(todo);
            return Created();
        }

        [HttpPut]
        [Route("/api/todo/{id}")] // POST /api/todo
        // Model Binding
        public IActionResult CreateTodo([FromBody] Todo todo, int id)
        {
            if (id != todo.Id)
                return BadRequest();

            var existingTodo = todoRepository.GetById(todo.Id);
            if (existingTodo == null)
                return NotFound();

            existingTodo.Title = todo.Title;
            existingTodo.Description = todo.Description;
            existingTodo.IsCompleted = todo.IsCompleted;

            var retorno = todoRepository.Update(existingTodo);
            return Ok(retorno);
        }

        [HttpDelete]
        [Route("/api/todo/{id}")]
        public IActionResult Delete(int id)
        {
            var existingTodo = todoRepository.GetById(id);
            if (existingTodo == null)
                return NotFound();

            todoRepository.Delete(id);
            return NoContent();
        }
    }
}