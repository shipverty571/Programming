using Microsoft.AspNetCore.Mvc.Rendering;
using NoteApp.Domain.ViewModels;
using NoteApp.TestValues;

namespace NoteApp.Domain.Services;

public class ListBoxService
{
    private ListBoxViewModel _listBoxViewModel;
    
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