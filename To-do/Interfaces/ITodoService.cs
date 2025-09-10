using To_do.DTOs;

namespace To_do.Interfaces
{
    public interface ITodoService 
    {
        Task<IEnumerable<TodoItemDto>> GetAllTodosAsync();
        Task<TodoItemDto?> GetTodoByIdAsync(int id);
        Task<CreateTodoItemDto> CreatedTodoAsnsc(CreateTodoItemDto createTodoItemDto);
        Task<UpdateTodoItemDto?> UpdateTodoAsync(int id, UpdateTodoItemDto updateTodoItemDto);
        Task<bool> DeleteTodoAsync(int id);
        Task<TodoItemDto?> TaggToggleCompletionAsync(int id);
    }
}
