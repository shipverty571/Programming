using System.ComponentModel.DataAnnotations;
using NoteApp.Domain.Enums;

namespace NoteApp.Domain.Entity
{
    /// <summary>
    /// Описывает сущность заметки.
    /// </summary>
    public class NoteEntity
    {
        /// <summary>
        /// Создает экземпляр класса <see cref="NoteEntity"/>.
        /// </summary>
        public NoteEntity()
        {
            TimeOfCreate = DateOnly.FromDateTime(DateTime.Now);
            TimeOfUpdate = DateOnly.FromDateTime(DateTime.Now);
        }

        /// <summary>
        /// Возвращает и задает уникальный идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Возвращает и задает имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает и задает описание.
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Возвращает и задает категорию.
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Возвращает и задает время создания сущности.
        /// </summary>
        public DateOnly TimeOfCreate { get; private set; }

        /// <summary>
        /// Возвращает и задает время обновления сущности.
        /// </summary>
        public DateOnly TimeOfUpdate { get; set; }
    }
}
