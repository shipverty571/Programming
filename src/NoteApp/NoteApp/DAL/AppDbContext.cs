using Microsoft.EntityFrameworkCore;
using NoteApp.Domain.Entity;

namespace NoteApp.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<NoteEntity> Notes { get; set; }
    }
}
