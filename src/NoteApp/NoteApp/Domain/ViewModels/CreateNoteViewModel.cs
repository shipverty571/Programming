namespace NoteApp.Domain.ViewModels;

public class CreateNoteViewModel
{
    /// <summary>
    /// Возвращает и задает заголовок.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Возвращает и задает описание.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Возвращает и задает категорию.
    /// </summary>
    public string Category { get; set; }
}