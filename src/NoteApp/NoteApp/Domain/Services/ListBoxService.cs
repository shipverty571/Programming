using NoteApp.DAL.Interfaces;
using NoteApp.Domain.DTO;
using NoteApp.Domain.Enums;
using NoteApp.Domain.ViewModels;

namespace NoteApp.Domain.Services;

/// <summary>
/// Сервис для инициализации объекта ListBoxViewModel.
/// </summary>
public class ListBoxService
{
    /// <summary>
    /// Репозиторий заметок.
    /// </summary>
    private readonly INoteRepository _noteRepository;

    /// <summary>
    /// Модель представления для ListBox.
    /// </summary>
    private ListBoxViewModel _listBoxViewModel;

    /// <summary>
    /// Создает экземпляр класса <see cref="ListBoxService" />.
    /// </summary>
    /// <param name="noteRepository">Репозиторий заметок.</param>
    public ListBoxService(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    /// <summary>
    /// Возвращает модель представления для списка заметок.
    /// </summary>
    public ListBoxViewModel ListBoxViewModel
    {
        get
        {
            if (_listBoxViewModel == null) _listBoxViewModel = GetNewListBoxViewModel();

            return _listBoxViewModel;
        }
    }

    /// <summary>
    /// Инициализирует фильтрованный список заметок.
    /// </summary>
    /// <param name="category">Категория.</param>
    /// <returns>Возвращает список фильтрованных заметок.</returns>
    public ListBoxViewModel GetFilteredListBoxViewModel(string category)
    {
        var listBoxViewModel = new ListBoxViewModel();
        var noteDTOList = _noteRepository
            .GetAll()
            .Where(note => note.Category == (Category)Convert.ToInt32(category))
            .OrderByDescending(note => note.TimeOfUpdate)
            .Select(note => new NoteDTO { Id = note.Id.ToString(), Title = note.Name })
            .ToList();
        listBoxViewModel.Items = noteDTOList;

        return listBoxViewModel;
    }

    /// <summary>
    /// Инициализарует список данными.
    /// </summary>
    /// <returns>Возвращает объект <see cref="ListBoxViewModel" />.</returns>
    private ListBoxViewModel GetNewListBoxViewModel()
    {
        var listBoxViewModel = new ListBoxViewModel();
        var noteDTOList = _noteRepository
            .GetAll()
            .OrderByDescending(n => n.TimeOfUpdate)
            .Select(note => new NoteDTO { Id = note.Id.ToString(), Title = note.Name })
            .ToList();
        listBoxViewModel.Items = noteDTOList;

        return listBoxViewModel;
    }
}