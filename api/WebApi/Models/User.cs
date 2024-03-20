namespace WebApi.Models;

public class User
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public List<Note>? Notes { get; set; } 
}