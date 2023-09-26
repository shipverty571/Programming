using NoteApp.DAL.Interfaces;
using NoteApp.Domain.ViewModels;

namespace NoteApp.Domain.Services;

/// <summary>
/// Сервисный класс для создания объектов <see cref="NoteViewModel" />.
/// </summary>
public class NoteViewModelFactory
{
    /// <summary>
    /// Репозиторий заметок.
    /// </summary>
    private readonly INoteRepository _noteRepository;

    /// <summary>
    /// Создает экземпляр класса <see cref="NoteViewModelFactory" />.
    /// </summary>
    /// <param name="noteRepository">Репозиторий заметок.</param>
    public NoteViewModelFactory(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    /// <summary>
    /// Создает объект <see cref="NoteViewModel" />.
    /// </summary>
    /// <param name="noteId">Уникальный идентификатор заметки.</param>
    /// <returns>Возвращает объект <see cref="NoteViewModel" />.</returns>
    public NoteViewModel Create(Guid noteId)
    {
        var allNotes = _noteRepository.GetAll();
        var note = allNotes.First(x => x.Id == noteId);
        return new NoteViewModel
        {
            Id = note.Id,
            Name = note.Name,
            Category = note.Category.ToString(),
            Description = note.Description,
            TimeOfCreate = note.TimeOfCreate.ToString("yyyy-MM-dd"),
            TimeOfUpdate = note.TimeOfUpdate.ToString("yyyy-MM-dd")
        };
    }
}