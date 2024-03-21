using Api.Dtos.Note;
using Api.Shared.Models;

namespace Api.Mappers;

public static class NoteMappers
{
    public static NoteDto ToNoteDto(this Note noteModel)
    {
        return new NoteDto
        {
            Id = noteModel.Id,
            Title = noteModel.Title,
            Content = noteModel.Content,
            CreatedOn = noteModel.CreatedOn
        };
    }

    public static Note ToNoteFromCreateDto(this CreateNoteRequestDto noteDto)
    {
        return new Note
        {         
            Title = noteDto.Title,
            Content = noteDto.Content
        };
    }
}
