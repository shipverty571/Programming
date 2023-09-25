using Microsoft.AspNetCore.Mvc.Rendering;
using NoteApp.DAL.Interfaces;
using NoteApp.Domain.ViewModels;

namespace NoteApp.Domain.Services;

/// <summary>
/// Сервис для инициализации объекта ListBoxViewModel.
/// </summary>
public class ListBoxService
{
    private readonly INoteRepository _noteRepository;

    private ListBoxViewModel _listBoxViewModel;

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
            if (_listBoxViewModel == null)
            {
                _listBoxViewModel = GetNewListBoxViewModel();
            }

            return _listBoxViewModel;
        }
    }

    /// <summary>
    /// Инициализарует список данными.
    /// </summary>
    /// <returns>Возвращает объект <see cref="ListBoxViewModel"/>.</returns>
    private ListBoxViewModel GetNewListBoxViewModel()
    {
        ListBoxViewModel listBoxViewModel = new ListBoxViewModel();
        listBoxViewModel.Items = new List<SelectListItem>();
        var allNotes = _noteRepository.GetAll().OrderBy(n => n.Id);
        foreach (var note in allNotes)
        {
            listBoxViewModel.Items.Add(new SelectListItem
            {
                Text = note.Name,
                Value = note.Id.ToString()
            });
        }

        return listBoxViewModel;
    }
}