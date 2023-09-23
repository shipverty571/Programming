using Microsoft.AspNetCore.Mvc.Rendering;
using NoteApp.Domain.ViewModels;
using NoteApp.TestValues;

namespace NoteApp.Domain.Services;

/// <summary>
/// Сервис для инициализации объекта ListBoxViewModel.
/// </summary>
public class ListBoxService
{
    /// <summary>
    /// Модель представления для списка заметок.
    /// </summary>
    private ListBoxViewModel _listBoxViewModel;
    
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
        foreach (var note in TestData.Notes)
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