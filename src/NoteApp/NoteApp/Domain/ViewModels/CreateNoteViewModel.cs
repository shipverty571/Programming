namespace NoteApp.Domain.ViewModels;

public class CreateNoteViewModel
{
    public int Id { get; set; } = -1;
    
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

    public string TimeOfCreate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
    
    public string TimeOfUpdate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
}