using NoteApp.DAL.Interfaces;
using NoteApp.Domain.Entity;
using NoteApp.Domain.Enums;
using NoteApp.Domain.Interfaces;
using NoteApp.Domain.ViewModels;

namespace NoteApp.Domain.Services;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;

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

    public void Remove(int noteId)
    {
        var allNote = _noteRepository.GetAll();
        var note = allNote.First(n => n.Id == noteId);
        _noteRepository.Delete(note);
    }
}