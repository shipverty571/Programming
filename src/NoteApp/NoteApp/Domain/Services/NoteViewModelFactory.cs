using NoteApp.Domain.Entity;
using NoteApp.Domain.ViewModels;

namespace NoteApp.Domain.Services
{
    public static class NoteViewModelFactory
    {
        public static NoteViewModel Create(NoteEntity note)
        {
            return new NoteViewModel
            {
                Name = note.Name,
                Category = note.Category.ToString(),
                Description = note.Description,
                TimeOfCreate = note.TimeOfCreate.ToString("yyyy-MM-dd"),
                TimeOfUpdate = note.TimeOfUpdate.ToString("yyyy-MM-dd")
            };
        }
    }
}
