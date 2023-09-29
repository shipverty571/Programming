namespace NoteApp.Domain.DTO;

/// <summary>
/// Класс передачи данных о заметках.
/// </summary>
public class NoteDTO
{
    /// <summary>
    /// Уникальный идентификатор заметки.
    /// </summary>
    public string Id { get; set; }
    
    /// <summary>
    /// Имя заметки.
    /// </summary>
    public string Title { get; set; }
}