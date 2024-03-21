using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Mappers;

namespace WebApi.Controllers;

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

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var note = _context.Notes.Find(id);

        if (note == null)
            return NotFound();


        return Ok(note.ToNoteDto());
    }
}
