using Microsoft.EntityFrameworkCore;
using To_do.Data;
using To_do.DTOs;
using To_do.Interfaces;
using To_do.Models;

namespace To_do.Services
{
    public class TodoService : ITodoService
    {
       private readonly TodoDbContext _context;

        public TodoService(TodoDbContext todoDbContext)
        {
            _context = todoDbContext;
        }

        private TodoItemDto MapToDto(TodoItem todoItem)
        {
            return new TodoItemDto
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                IsCompleted = todoItem.IsCompleted,
                CreatedAt = todoItem.CreatedAt,
                CompletedAt = todoItem.CompletedAt,
                UpdatedAt = todoItem.UpdatedAt
            };
        }
        public async Task<CreateTodoItemDto> CreatedTodoAsnsc(CreateTodoItemDto createTodoItemDto)
        {
            var todoItem = new TodoItem
            {
                Title = createTodoItemDto.Title,
                Description = createTodoItemDto.Description ?? string.Empty,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return new CreateTodoItemDto { Title = todoItem.Title, Description = todoItem.Description };

        }

        public async Task<bool> DeleteTodoAsync(int id)
        {
           var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return false;
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<TodoItemDto>> GetAllTodosAsync()
        {
            var todos = await _context.TodoItems.OrderByDescending(t => t.CreatedAt).ToListAsync();

            return todos.Select(MapToDto);
        }

        public async Task<TodoItemDto?> GetTodoByIdAsync(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            return todo == null ? null : MapToDto(todo);          
        }

        public async Task<TodoItemDto?> TaggToggleCompletionAsync(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return null;
            }

            todoItem.IsCompleted = !todoItem.IsCompleted;
            todoItem.CompletedAt = todoItem.IsCompleted ? DateTime.UtcNow : null ;
            todoItem.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return MapToDto(todoItem);
        }

        public async Task<UpdateTodoItemDto?> UpdateTodoAsync(int id, UpdateTodoItemDto updateTodoItemDto)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
                return null;

            todoItem.Title = updateTodoItemDto.Title;
            todoItem.Description = updateTodoItemDto.Description;
            todoItem.UpdatedAt = DateTime.Now;

            if (updateTodoItemDto.IsCompleted != todoItem.IsCompleted)
            {
                todoItem.IsCompleted = updateTodoItemDto.IsCompleted;
                todoItem.CompletedAt = updateTodoItemDto.IsCompleted ? DateTime.UtcNow : null;
            }

            await _context.SaveChangesAsync();
            
            return new UpdateTodoItemDto 
            { 
                Title = todoItem.Title, 
                Description = todoItem.Description, 
                IsCompleted = todoItem.IsCompleted 
            };
        }
    }
}
