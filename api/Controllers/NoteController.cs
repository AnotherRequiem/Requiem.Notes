using Microsoft.AspNetCore.Mvc;
using Api.Data;
using Api.Dtos.Note;
using Api.Mappers;

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
    public IActionResult GetAll()
    {
        var notes = _context.Notes.ToList()
            .Select(n => n.ToNoteDto());

        return Ok(notes);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateNoteRequestDto noteDto)
    {
        var noteModel = noteDto.ToNoteFromCreateDto();

        _context.Add(noteModel);
        _context.SaveChanges();

        return Ok(noteModel.ToNoteDto());
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateNoteRequestDto noteDto)
    {
        var noteModel = _context.Notes.FirstOrDefault(n => n.Id == id);

        if (noteModel == null)
            return NotFound();

        noteModel.Title = noteDto.Title;
        noteModel.Content = noteDto.Content;
        
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var noteModel = _context.Notes.FirstOrDefault(n => n.Id == id);

        if (noteModel == null)
            return NotFound();

        _context.Notes.Remove(noteModel);
        _context.SaveChanges();

        return NoContent();
    }
}
