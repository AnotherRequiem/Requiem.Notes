using Api.Data;
using Api.Dtos.Note;
using Api.Interfaces;
using Api.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class NoteRepository : INoteRepository
{
    private readonly ApplicationDbContext _context;

    public NoteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Note>> GetAllAsync()
    {
        return await _context.Notes.ToListAsync();
    }

    public async Task<Note> CreateAsync(Note noteModel)
    {
        await _context.Notes.AddAsync(noteModel);
        await _context.SaveChangesAsync();

        return noteModel;
    }
    public async Task<Note?> UpdateAsync(Guid id, UpdateNoteRequestDto noteDto)
    {
        var existingNote = await _context.Notes.FirstOrDefaultAsync(x => x.Id == id);

        if (existingNote == null)
            return null;

        existingNote.Title = noteDto.Title;
        existingNote.Content = noteDto.Content;

        await _context.SaveChangesAsync();

        return existingNote;
    }

    public async Task<Note?> DeleteAsync(Guid id)
    {
        var noteModel = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);

        if (noteModel == null)
            return null;

        _context.Notes.Remove(noteModel);
        _context.SaveChanges();

        return noteModel;
    }

}
