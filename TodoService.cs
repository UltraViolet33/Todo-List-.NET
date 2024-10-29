using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using TodoList.Pages;

public class TodoService
{
    private List<TodoItem> todos = new List<TodoItem>();

    public List<TodoItem> GetTodos()
    {
        return todos;
    }


    public void AddTodo(TodoItem todo)
    {
        todos.Add(todo);
        SaveTodos();
    }

    public void DeleteTodo(TodoItem todo)
    {
        todos.Remove(todo);
        SaveTodos();
    }


    public List<TodoItem> GetTodoFromFile()
    {
        string json = System.IO.File.ReadAllText("todos.json");
        if (string.IsNullOrEmpty(json))
        {
            return new List<TodoItem>();
        }

        return System.Text.Json.JsonSerializer.Deserialize<List<TodoItem>>(json);
    }

    private void SaveTodos()
    {
        string json = System.Text.Json.JsonSerializer.Serialize(todos);
        System.IO.File.WriteAllText("todos.json", json);
    }
}