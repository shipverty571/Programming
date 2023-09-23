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

    public void Add(CreateNoteViewModel note)
    {
        var noteEntity = new NoteEntity
        {
            Name = note.Name,
            Description = note.Description,
            Category = Enum.Parse<Category>(note.Category)
        };
        _noteRepository.Create(noteEntity);
    }
}