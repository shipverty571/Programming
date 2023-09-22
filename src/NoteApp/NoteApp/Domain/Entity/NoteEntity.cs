using NoteApp.Domain.Enums;

namespace NoteApp.Domain.Entity
{
    public class NoteEntity
    {
        private readonly int _id;

        private static int _allNotes;

        public NoteEntity()
        {
            _allNotes++;
            _id = _allNotes;
            TimeOfCreate = DateOnly.FromDateTime(DateTime.Now);
            TimeOfUpdate = DateOnly.FromDateTime(DateTime.Now);
        }

        public int Id => _id;

        public string Name { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public DateOnly TimeOfCreate { get; }

        public DateOnly TimeOfUpdate { get; set; }
    }
}
