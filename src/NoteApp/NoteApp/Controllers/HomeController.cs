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
    
        /// <summary>
        /// Создает экземпляр класса <see cref="HomeController"/>.
        /// </summary>
        /// <param name="listBoxService">Сервис для ListBoxViewModel.</param>
        public HomeController(ListBoxService listBoxService)
        {
            _listBoxService = listBoxService;
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
        /// Отправляет данные выбранной заметки.
        /// </summary>
        /// <param name="noteId">Уникальный идентификатор выбранной записи.</param>
        /// <returns>Возвращает Json объект данных.</returns>
        [HttpPost]
        public JsonResult LoadSelectedNote(int noteId)
        {
            var noteViewModel = NoteViewModelFactory.Create(noteId);
            return Json(noteViewModel);
        }
    }
}