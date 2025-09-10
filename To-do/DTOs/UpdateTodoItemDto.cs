using System.ComponentModel.DataAnnotations;

namespace To_do.DTOs
{
    public class UpdateTodoItemDto
    {
        [Required]
        [StringLength(200, ErrorMessage = "Title cannot be longer than 200 characters.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
