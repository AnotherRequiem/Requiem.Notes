﻿namespace Api.Dtos.Note;

public class CreateNoteRequestDto
{
    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}