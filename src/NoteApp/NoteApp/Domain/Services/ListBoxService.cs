using NoteApp.DAL.Interfaces;
using NoteApp.Domain.DTO;
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
    /// Инициализарует список данными.
    /// </summary>
    /// <returns>Возвращает объект <see cref="ListBoxViewModel" />.</returns>
    private ListBoxViewModel GetNewListBoxViewModel()
    {
        var listBoxViewModel = new ListBoxViewModel();
        listBoxViewModel.Items = new List<NoteDTO>();
        var allNotes =
            _noteRepository.GetAll().OrderByDescending(n => n.TimeOfUpdate);
        foreach (var note in allNotes)
            listBoxViewModel.Items.Add(new NoteDTO
            {
                Title = note.Name,
                Id = note.Id.ToString()
            });

        return listBoxViewModel;
    }
}