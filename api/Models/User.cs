using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models;

[Table("Users")]
public class User
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public List<Note>? Notes { get; set; } 
}