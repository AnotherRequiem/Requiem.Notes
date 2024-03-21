namespace WebApi.Dtos.Note;

public class NoteDto
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? EditedOn { get; set; }

    public Guid UserId { get; set; }
}
