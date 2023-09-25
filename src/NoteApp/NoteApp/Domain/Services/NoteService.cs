using NoteApp.DAL.Interfaces;
using NoteApp.Domain.Entity;
using NoteApp.Domain.Enums;
using NoteApp.Domain.Interfaces;
using NoteApp.Domain.ViewModels;

namespace NoteApp.Domain.Services;

/// <summary>
/// Сервис для добавления заметок в БД.
/// </summary>
public class NoteService : INoteService
{
    /// <summary>
    /// Репозиторий заметок.
    /// </summary>
    private readonly INoteRepository _noteRepository;

    /// <summary>
    /// Создает экземпляр класса <see cref="NoteService"/>.
    /// </summary>
    /// <param name="noteRepository">Репозиторий заметок.</param>
    public NoteService(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }
    
    public void Add(NoteViewModel note)
    {
        var noteEntity = new NoteEntity
        {
            Name = note.Name,
            Description = note.Description,
            Category = Enum.Parse<Category>(note.Category)
        };
        _noteRepository.Create(noteEntity);
    }

    public void Edit(NoteViewModel newNote)
    {
        var allNote = _noteRepository.GetAll();
        var note = allNote.First(n => n.Id == newNote.Id);
        note.Name = newNote.Name;
        note.Description = newNote.Description;
        note.Category = Enum.Parse<Category>(newNote.Category);
        note.TimeOfUpdate = DateOnly.FromDateTime(DateTime.Now);

        _noteRepository.Update(note);
    }

    public void Remove(Guid noteId)
    {
        var allNote = _noteRepository.GetAll();
        var note = allNote.First(n => n.Id == noteId);
        _noteRepository.Delete(note);
    }
}