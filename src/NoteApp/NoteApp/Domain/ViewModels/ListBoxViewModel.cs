using Microsoft.AspNetCore.Mvc.Rendering;

namespace NoteApp.Domain.ViewModels
{
    public class ListBoxViewModel
    {
        public int SelectedNoteId { get; set; }

        public List<SelectListItem> Items { get; set; }
    }
}
