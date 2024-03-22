using Api.Dtos.Note;
using Api.Shared.Models;

namespace Api.Interfaces;

public interface INoteRepository
{
    Task<List<Note>> GetAllAsync();

    Task<Note> CreateAsync(Note noteModel);

    Task<Note?> UpdateAsync(Guid id, UpdateNoteRequestDto noteDto);

    Task<Note?> DeleteAsync(Guid id);
}