using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi
{
    public class TodoList
    {
        public static Dictionary<int, Todo> Tasks { get; set; }

        static TodoList()
        {
            Tasks = new()
            {
                { 1, new() { Id = 1, Title = "Task 1", Description = "Description for Task 1", IsCompleted = false } },
                { 2, new() { Id = 2, Title = "Task 2", Description = "Description for Task 2", IsCompleted = true } },
                { 3, new() { Id = 3, Title = "Task 3", Description = "Description for Task 3", IsCompleted = false } }
            };
        }
    }
}
