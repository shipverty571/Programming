using Microsoft.AspNetCore.Mvc;
using NoteApp.Domain.Services;

namespace NoteApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ListBoxService listBoxService)
        {
            ListBoxService = listBoxService;
        }

        public ListBoxService ListBoxService { get; }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View(ListBoxService.ListBoxViewModel);
        }

        [HttpPost]
        public JsonResult LoadSelectedNote(int noteId)
        {
            var noteViewModel = NoteViewModelFactory.Create(noteId);
            return Json(noteViewModel);
        }
    }
}