using Microsoft.AspNetCore.Mvc;
using NoteApp.Domain.Interfaces;
using NoteApp.Domain.Services;
using NoteApp.Domain.ViewModels;

namespace NoteApp.Controllers
{
    /// <summary>
    /// Главный контроллер.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Сервис для ListBoxViewModel.
        /// </summary>
        private readonly ListBoxService _listBoxService;

        private readonly NoteViewModelFactory _noteViewModelFactory;

        private readonly INoteService _noteService;
    
        /// <summary>
        /// Создает экземпляр класса <see cref="HomeController"/>.
        /// </summary>
        /// <param name="listBoxService">Сервис для ListBoxViewModel.</param>
        public HomeController(
            ListBoxService listBoxService, 
            NoteViewModelFactory noteViewModelFactory, 
            INoteService noteService)
        {
            _listBoxService = listBoxService;
            _noteViewModelFactory = noteViewModelFactory;
            _noteService = noteService;
        }
        
        /// <summary>
        /// Главная страница.
        /// </summary>
        /// <returns>Возвращает представление главного окна.</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View(_listBoxService.ListBoxViewModel);
        }

        /// <summary>
        /// Страница добавления и редактирования задачи.
        /// </summary>
        /// <returns>Возвращает представление окна добавления и удаления задачи.</returns>
        [HttpGet]
        public ActionResult EditNote(int noteId = -1)
        {
            if (noteId == -1)
            {
                return View(new NoteViewModel());
            }
            else
            {
                var note = _noteViewModelFactory.Create(noteId);
                return View(note);
            }
            
        }

        /// <summary>
        /// Отправляет данные выбранной заметки.
        /// </summary>
        /// <param name="noteId">Уникальный идентификатор выбранной записи.</param>
        /// <returns>Возвращает Json объект данных.</returns>
        [HttpPost]
        public IActionResult LoadSelectedNote(int noteId)
        {
            var noteViewModel = _noteViewModelFactory.Create(noteId);
            return Json(noteViewModel);
        }

        [HttpPost]
        public string Index(NoteViewModel note)
        {
            if (note.Id == -1)
            {
                _noteService.Add(note);
            }
            else
            {
                _noteService.Edit(note);
            }

            return "Success";
        }

        [HttpPost]
        public string RemoveNote(int noteId)
        {
            _noteService.Remove(noteId);
            return "Removed";
        }
    }
}