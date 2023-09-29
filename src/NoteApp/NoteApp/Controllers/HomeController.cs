using Microsoft.AspNetCore.Mvc;
using NoteApp.Domain.Interfaces;
using NoteApp.Domain.Services;
using NoteApp.Domain.ViewModels;

namespace NoteApp.Controllers;

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
    /// Сервис для добавления заметок в репозиторий.
    /// </summary>
    private readonly INoteService _noteService;

    /// <summary>
    /// Сервис для создания объектов NoteViewModel.
    /// </summary>
    private readonly NoteViewModelFactory _noteViewModelFactory;

    /// <summary>
    /// Создает экземпляр класса <see cref="HomeController" />.
    /// </summary>
    /// <param name="listBoxService">Сервис для ListBoxViewModel.</param>
    /// <param name="noteViewModelFactory">Сервис для создания объектов NoteViewModel.</param>
    /// <param name="noteService">Сервис для добавления заметок в репозиторий.</param>
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
    public IActionResult EditNote(Guid noteId)
    {
        if (noteId == Guid.Empty) return View(new NoteViewModel());

        var note = _noteViewModelFactory.Create(noteId);
        return View(note);
    }

    /// <summary>
    /// Отправляет данные выбранной заметки.
    /// </summary>
    /// <param name="noteId">Уникальный идентификатор выбранной записи.</param>
    /// <returns>Возвращает Json объект данных.</returns>
    [HttpPost]
    public IActionResult LoadSelectedNote(Guid noteId)
    {
        var noteViewModel = _noteViewModelFactory.Create(noteId);
        return Json(noteViewModel);
    }

    /// <summary>
    /// Добавляет полученные данные в БД или редактирует их.
    /// </summary>
    /// <param name="note">Модель представления заметки.</param>
    /// <returns>Возвращает представление.</returns>
    [HttpPost]
    public IActionResult EditNote(NoteViewModel note)
    {
        if (!ModelState.IsValid)
        {
            return View(note);
        }
        
        if (note.Id == Guid.Empty)
        {
            _noteService.Add(note);
        }
        else
        {
            _noteService.Edit(note);
        }
        
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Получает идентификатор заметки, которую нужно удалить.
    /// </summary>
    /// <param name="noteId">Идентификатор заметки.</param>
    /// <returns>Возвращает строку Removed.</returns>
    [HttpPost]
    public string RemoveNote(Guid noteId)
    {
        _noteService.Remove(noteId);
        return "Removed";
    }
}