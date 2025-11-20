using System.Collections.Generic;
using TodoApp.Models;

namespace TodoApp.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAll();
        Todo GetById(int id);
        bool Update(Todo todo);
        bool Delete(int id);
        Todo Create(Todo todo);
    }
}