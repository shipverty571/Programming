using NoteApp.Domain.ViewModels;

namespace NoteApp.Domain.Interfaces;

public interface INoteService
{
    public void Add(CreateNoteViewModel note);
}