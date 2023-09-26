using NoteApp.DAL.Interfaces;
using NoteApp.Domain.Entity;

namespace NoteApp.DAL;

/// <summary>
/// Репозиторий заметок.
/// </summary>
public class NoteRepository : INoteRepository
{
    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    private readonly AppDbContext _appDbContext;

    /// <summary>
    /// Создает экземпляр класса <see cref="NoteRepository" />.
    /// </summary>
    /// <param name="appDbContext">Контекст базы данных.</param>
    public NoteRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    /// <summary>
    /// Добавляет заметку в БД.
    /// </summary>
    /// <param name="note">Заметка.</param>
    public async Task Create(NoteEntity note)
    {
        await _appDbContext.Notes.AddAsync(note);
        await _appDbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Получает данные с БД.
    /// </summary>
    /// <returns>Возвращает коллекцию объектов БД.</returns>
    public IQueryable<NoteEntity> GetAll()
    {
        return _appDbContext.Notes;
    }

    /// <summary>
    /// Обновляет данные о заметке в БД.
    /// </summary>
    /// <param name="note">Заметка.</param>
    public async Task Update(NoteEntity note)
    {
        _appDbContext.Notes.Update(note);
        await _appDbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Удаляет заметку из БД.
    /// </summary>
    /// <param name="note">Заметка.</param>
    public async Task Delete(NoteEntity note)
    {
        _appDbContext.Notes.Remove(note);
        await _appDbContext.SaveChangesAsync();
    }
}