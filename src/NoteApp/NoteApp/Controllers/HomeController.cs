using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NoteApp.Domain.Services;
using NoteApp.Domain.ViewModels;
using NoteApp.TestValues;

namespace NoteApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController() 
        {
            ListBoxViewModel = new ListBoxViewModel();
            ListBoxViewModel.Items = new List<SelectListItem>();
            foreach (var note in TestData.Notes)
            {
                ListBoxViewModel.Items.Add(new SelectListItem 
                { 
                    Text = note.Name,
                    Value = note.Id.ToString()
                });
            }
        }

        public ListBoxViewModel ListBoxViewModel { get; set; }

        [HttpGet]
        public IActionResult Index()
        {
            return View(ListBoxViewModel);
        }

        [HttpPost]
        public JsonResult LoadSelectedNote(int noteId)
        {
            var note = TestData.Notes.First(x => x.Id == noteId);
            var noteViewModel = NoteViewModelFactory.Create(note);
            return Json(noteViewModel);
        }
    }
}