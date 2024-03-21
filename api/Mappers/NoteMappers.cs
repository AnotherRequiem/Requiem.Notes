using WebApi.Dtos.Note;
using WebApi.Models;

namespace WebApi.Mappers;

public static class NoteMappers
{
    public static NoteDto ToNoteDto(this Note noteModel)
    {
        return new NoteDto
        {
            Id = noteModel.Id,
            Title = noteModel.Title,
            Content = noteModel.Content,
            CreatedOn = noteModel.CreatedOn,
            EditedOn = noteModel.EditedOn,
            UserId = noteModel.UserId
        };
    }
}
