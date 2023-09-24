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
        public IActionResult EditNote()
        {
            return View();
        }

        /// <summary>
        /// Отправляет данные выбранной заметки.
        /// </summary>
        /// <param name="noteId">Уникальный идентификатор выбранной записи.</param>
        /// <returns>Возвращает Json объект данных.</returns>
        [HttpPost]
        public JsonResult LoadSelectedNote(int noteId)
        {
            var noteViewModel = _noteViewModelFactory.Create(noteId);
            return Json(noteViewModel);
        }

        [HttpPost]
        public JsonResult Index(string name, string category, string description)
        {
            var note = new CreateNoteViewModel
            {
                Name = name,
                Category = category,
                Description = description
            };
            _noteService.Add(note);
            return Json(note);
        }
    }
}