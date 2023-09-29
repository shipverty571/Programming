using System.ComponentModel.DataAnnotations;

namespace NoteApp.Domain.ViewModels;

/// <summary>
/// Модель представления данных заметки.
/// </summary>
public class NoteViewModel
{
    /// <summary>
    /// Максимальное количество символов в названии.
    /// </summary>
    private const int MaxCountOfSymbolsName = 50;
    
    /// <summary>
    /// Возвращает и задает уникальный идентификатор.
    /// </summary>
    public Guid Id { get; set; } = Guid.Empty;

    /// <summary>
    /// Возвращает и задает заголовок.
    /// </summary>
    [Required(ErrorMessage = "The Name field must have the value")]
    [StringLength(MaxCountOfSymbolsName, ErrorMessage = "The number of characters must be less than 50")]
    public string Name { get; set; }

    /// <summary>
    /// Возвращает и задает описание.
    /// </summary>
    [Required(ErrorMessage = "The Description field must have the value")]
    public string Description { get; set; }

    /// <summary>
    /// Возвращает и задает категорию.
    /// </summary>
    [Required(ErrorMessage = "The Category field must have the value")]
    public string Category { get; set; } = Enum.GetName(Enums.Category.Work);

    /// <summary>
    /// Возвращает и задает дату создания заметки.
    /// </summary>
    public string TimeOfCreate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");

    /// <summary>
    /// Возвращает и задает дату обновления данных.
    /// </summary>
    public string TimeOfUpdate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
}