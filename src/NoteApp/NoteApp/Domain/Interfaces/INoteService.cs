using NoteApp.Domain.ViewModels;

namespace NoteApp.Domain.Interfaces;

public interface INoteService
{
    public void Add(CreateNoteViewModel note);

    public void Edit(CreateNoteViewModel newNote);

    public void Remove(int noteId);
}