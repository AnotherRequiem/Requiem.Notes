using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Note;

public class UpdateNoteRequestDto
{
    [Required]
    [MinLength(4, ErrorMessage = "Title must be 4 characters at least")]
    [MaxLength(20, ErrorMessage = "Title can not be over 20 characters")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MinLength(1, ErrorMessage = "Content must be 1 characters at least")]
    [MaxLength(280, ErrorMessage = "Content can not be over 280 characters")]
    public string Content { get; set; } = string.Empty;
}
