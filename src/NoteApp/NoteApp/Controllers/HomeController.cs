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
        /// Создает экземпляр класса <see cref="HomeController"/>.
        /// </summary>
        /// <param name="listBoxService">Сервис для ListBoxViewModel.</param>
        public HomeController(ListBoxService listBoxService)
        {
            ListBoxService = listBoxService;
        }

        /// <summary>
        /// Возвращает сервис для ListBoxViewModel.
        /// </summary>
        public ListBoxService ListBoxService { get; }
        
        /// <summary>
        /// Главная страница.
        /// </summary>
        /// <returns>Возвращает представление главного окна.</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View(ListBoxService.ListBoxViewModel);
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