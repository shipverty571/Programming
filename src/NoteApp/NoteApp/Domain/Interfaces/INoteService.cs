using NoteApp.Domain.ViewModels;

namespace NoteApp.Domain.Interfaces;

/// <summary>
/// Интерфейс сервиса для добавления заметок в БД.
/// </summary>
public interface INoteService
{
    /// <summary>
    /// Добавляет заметку в БД.
    /// </summary>
    /// <param name="note">Заметка.</param>
    public void Add(NoteViewModel note);

    /// <summary>
    /// Редактирует заметку в БД.
    /// </summary>
    /// <param name="newNote">Заметка.</param>
    public void Edit(NoteViewModel newNote);
    
    /// <summary>
    /// Удаляет заметку из БД.
    /// </summary>
    /// <param name="noteId">Идентификатор заметки.</param>
    public void Remove(Guid noteId);
}