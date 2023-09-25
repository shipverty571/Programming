using System.ComponentModel.DataAnnotations;
using NoteApp.Domain.Enums;

namespace NoteApp.Domain.Entity
{
    public class NoteEntity
    {
        public NoteEntity()
        {
            TimeOfCreate = DateOnly.FromDateTime(DateTime.Now);
            TimeOfUpdate = DateOnly.FromDateTime(DateTime.Now);
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public DateOnly TimeOfCreate { get; private set; }

        public DateOnly TimeOfUpdate { get; set; }
    }
}
