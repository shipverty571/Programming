using Microsoft.AspNetCore.Mvc;
using NoteApp.Domain.Services;

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
    
        /// <summary>
        /// Создает экземпляр класса <see cref="HomeController"/>.
        /// </summary>
        /// <param name="listBoxService">Сервис для ListBoxViewModel.</param>
        public HomeController(
            ListBoxService listBoxService, 
            NoteViewModelFactory noteViewModelFactory)
        {
            _listBoxService = listBoxService;
            _noteViewModelFactory = noteViewModelFactory;
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
    }
}