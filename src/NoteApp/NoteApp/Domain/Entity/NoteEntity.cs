using System.ComponentModel.DataAnnotations;
using NoteApp.Domain.Enums;

namespace NoteApp.Domain.Entity
{
    public class NoteEntity
    {
        private  int _id;

        private static int _allNotes;

        public NoteEntity()
        {
            _allNotes++;
            _id = _allNotes;
            TimeOfCreate = DateOnly.FromDateTime(DateTime.Now);
            TimeOfUpdate = DateOnly.FromDateTime(DateTime.Now);
        }

        [Required]
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public DateOnly TimeOfCreate { get; private set; }

        public DateOnly TimeOfUpdate { get; set; }
    }
}
