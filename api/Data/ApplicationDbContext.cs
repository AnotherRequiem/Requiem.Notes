using Microsoft.EntityFrameworkCore;
using Api.Shared.Models;

namespace Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Note> Notes { get; set; }
    }
}
