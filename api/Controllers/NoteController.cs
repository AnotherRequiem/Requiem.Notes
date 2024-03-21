using Microsoft.AspNetCore.Mvc;
using Api.Data;
using Api.Dtos.Note;
using Api.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("api/note")]
public class NoteController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public NoteController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var notes = await _context.Notes.ToListAsync();

        var noteDto = notes.Select(n => n.ToNoteDto());

        return Ok(notes);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNoteRequestDto noteDto)
    {
        var noteModel = noteDto.ToNoteFromCreateDto();

        await _context.AddAsync(noteModel);
        await _context.SaveChangesAsync();

        return Ok(noteModel.ToNoteDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateNoteRequestDto noteDto)
    {
        var noteModel = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);

        if (noteModel == null)
            return NotFound();

        noteModel.Title = noteDto.Title;
        noteModel.Content = noteDto.Content;
        
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var noteModel = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);

        if (noteModel == null)
            return NotFound();

        _context.Notes.Remove(noteModel);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
