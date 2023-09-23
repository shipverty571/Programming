using NoteApp.Domain.Entity;
using NoteApp.Domain.ViewModels;
using NoteApp.TestValues;

namespace NoteApp.Domain.Services
{
    public static class NoteViewModelFactory
    {
        public static NoteViewModel Create(int noteId)
        {
            var note = TestData.Notes.First(x => x.Id == noteId);
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
