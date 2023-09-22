using NoteApp.Domain.Enums;

namespace NoteApp.Domain.ViewModels
{
    public class NoteViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string TimeOfCreate { get; set; }

        public string TimeOfUpdate { get; set; }
    }
}
