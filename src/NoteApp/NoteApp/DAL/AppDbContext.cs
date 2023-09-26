using Microsoft.EntityFrameworkCore;
using NoteApp.Domain.Entity;

namespace NoteApp.DAL;

/// <summary>
/// Контекст базы данных.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Возвращает экземпляр класса <see cref="AppDbContext" />.
    /// </summary>
    /// <param name="options">Опции для базы данных.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Возвращает и задает список заметок.
    /// </summary>
    public DbSet<NoteEntity> Notes { get; set; }
}