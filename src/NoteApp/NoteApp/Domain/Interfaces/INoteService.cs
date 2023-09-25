using NoteApp.Domain.ViewModels;

namespace NoteApp.Domain.Interfaces;

public interface INoteService
{
    public void Add(NoteViewModel note);

    public void Edit(NoteViewModel newNote);

    public void Remove(Guid noteId);
}