﻿using NoteApp.Domain.DTO;

namespace NoteApp.Domain.ViewModels;

/// <summary>
/// Модель представления для списка заметок.
/// </summary>
public class ListBoxViewModel
{
    /// <summary>
    /// Возвращает и задает список данных для инициализации списка в представлении.
    /// </summary>
    public List<NoteDTO> Items { get; set; }
}