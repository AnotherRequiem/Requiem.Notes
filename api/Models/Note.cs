using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models;

[Table("Notes")]
public class Note
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? EditedOn { get; set; }

    public Guid UserId { get; set; }

    //Navigation property for EF
    public User User { get; set; }
}
