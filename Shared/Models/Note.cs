using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Shared.Models;

[Table("Notes")]
public class Note
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public DateTime CreatedOn { get; set; } = DateTime.Now;
}
