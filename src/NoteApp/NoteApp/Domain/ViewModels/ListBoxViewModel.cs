using Microsoft.AspNetCore.Mvc.Rendering;

namespace NoteApp.Domain.ViewModels;

/// <summary>
/// Модель представления для списка заметок.
/// </summary>
public class ListBoxViewModel
{
    /// <summary>
    /// Возвращает и задает уникальный идентификатор выбранной заметки.
    /// </summary>
    public int SelectedNoteId { get; set; }

    /// <summary>
    /// Возвращает и задает список данных для инициализации списка в представлении.
    /// </summary>
    public List<SelectListItem> Items { get; set; }
}