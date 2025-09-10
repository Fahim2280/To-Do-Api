using Microsoft.AspNetCore.Mvc;
using To_do.DTOs;
using To_do.Interfaces;
using To_do.Models;

namespace To_do.Controllers
{
    [ApiController()]
    [Route("TO-DO")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("api/todos/List")]
        public async Task<ActionResult> GetAllTodos()
        {
            var todos = await _todoService.GetAllTodosAsync();
            return Ok(todos);
        }

        [HttpPost("api/todos/Created")]
        public async Task<ActionResult<TodoItemDto>> createTodo(CreateTodoItemDto createTodoItemDto)
        {
            var createdTodo = await _todoService.CreatedTodoAsnsc(createTodoItemDto);
            return CreatedAtAction(nameof(GetAllTodos), new {id = createdTodo.Title }, createdTodo);
        }

        [HttpGet("api/todos/{id}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoById(int id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);
            if (todo == null)
            {
                return NotFound($"Todo item with ID {id} not found.");

            }
            return Ok (todo);
        }

        [HttpPatch("api/toggle/{id}")]
        public async Task<ActionResult<TodoItem>> ToggleCompletion(int id)
        {
            var updateTodo = await _todoService.TaggToggleCompletionAsync(id);
            if (updateTodo == null)
                return NotFound($"Todo item with ID {id} not found.");

            return Ok(updateTodo);
        }
    }
}
