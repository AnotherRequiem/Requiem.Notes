using Microsoft.AspNetCore.Mvc;
using Api.Data;
using Api.Dtos.Note;
using Api.Mappers;
using Microsoft.EntityFrameworkCore;
using Api.Interfaces;

namespace Api.Controllers;

[Route("api/note")]
public class NoteController : ControllerBase
{
    private readonly INoteRepository _noteRepository;

    public NoteController(INoteRepository noteRepository )
    {
        _noteRepository = noteRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {      
        var notes = await _noteRepository.GetAllAsync();

        var noteDto = notes.Select(n => n.ToNoteDto());

        return Ok(notes);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNoteRequestDto noteDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var noteModel = noteDto.ToNoteFromCreateDto();

        await _noteRepository.CreateAsync(noteModel);      

        return Ok(noteModel.ToNoteDto());
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateNoteRequestDto noteDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var noteModel = await _noteRepository.UpdateAsync(id, noteDto);

        if (noteModel == null)
            return NotFound();

        return Ok(noteModel.ToNoteDto());
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var noteModel = await _noteRepository.DeleteAsync(id);

        if (noteModel == null)
            return NotFound();

        return NoContent();
    }
}
