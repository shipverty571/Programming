using NoteApp.DAL.Interfaces;
using NoteApp.Domain.ViewModels;

namespace NoteApp.Domain.Services;

public class CreateNoteViewModelFactory
{
    private readonly INoteRepository _noteRepository;

    public CreateNoteViewModelFactory(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    /// <summary>
    /// Создает объект <see cref="NoteViewModel"/>.
    /// </summary>
    /// <param name="noteId">Уникальный идентификатор заметки.</param>
    /// <returns>Возвращает объект <see cref="NoteViewModel"/>.</returns>
    public CreateNoteViewModel Create(int noteId)
    {
        var allNotes = _noteRepository.GetAll();
        var note = allNotes.First(x => x.Id == noteId);
        return new CreateNoteViewModel
        {
            Id = noteId,
            Name = note.Name,
            Category = note.Category.ToString(),
            Description = note.Description,
            TimeOfCreate = note.TimeOfCreate.ToString("yyyy-MM-dd"),
            TimeOfUpdate = note.TimeOfUpdate.ToString("yyyy-MM-dd")
        };
    }
}