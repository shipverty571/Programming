using NoteApp.Domain.Entity;

namespace NoteApp.DAL.Interfaces;

/// <summary>
/// Интерфейс для репозитория заметок.
/// </summary>
public interface INoteRepository
{
    /// <summary>
    /// Добавляет заметку в БД.
    /// </summary>
    /// <param name="note">Заметка.</param>
    public Task Create(NoteEntity note);

    /// <summary>
    /// Получает данные с БД.
    /// </summary>
    /// <returns>Возвращает коллекцию объектов БД.</returns>
    public IQueryable<NoteEntity> GetAll();

    /// <summary>
    /// Обновляет данные о заметке в БД.
    /// </summary>
    /// <param name="note">Заметка.</param>
    public Task Update(NoteEntity note);

    /// <summary>
    /// Удаляет заметку из БД.
    /// </summary>
    /// <param name="note">Заметка.</param>
    public Task Delete(NoteEntity note);
}