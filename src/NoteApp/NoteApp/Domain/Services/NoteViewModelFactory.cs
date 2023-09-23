using NoteApp.Domain.ViewModels;
using NoteApp.TestValues;

namespace NoteApp.Domain.Services
{
    /// <summary>
    /// Сервисный класс для создания объектов <see cref="NoteViewModel"/>.
    /// </summary>
    public static class NoteViewModelFactory
    {
        /// <summary>
        /// Создает объект <see cref="NoteViewModel"/>.
        /// </summary>
        /// <param name="noteId">Уникальный идентификатор заметки.</param>
        /// <returns>Возвращает объект <see cref="NoteViewModel"/>.</returns>
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
