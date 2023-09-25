namespace NoteApp.Domain.ViewModels
{
    /// <summary>
    /// Модель представления данных заметки.
    /// </summary>
    public class NoteViewModel
    {
        public Guid Id { get; set; } = Guid.Empty;
        
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
}
