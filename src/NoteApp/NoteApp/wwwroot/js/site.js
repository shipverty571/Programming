/**
 * Показывает информацию при выборе элемента списка.
 */
$(function () {
    $('select#NotesListBox').change(function () {
        var noteId = $(this).val();
        
        if (noteId == null)
        {
            $("button#EditButton").prop("disabled", true);
            $("button#RemoveButton").prop("disabled", true);
        }
        else{
            $("button#EditButton").prop("disabled", false);
            $("button#RemoveButton").prop("disabled", false);
        }
        
        $.ajax({
            url: '/Home/LoadSelectedNote/',
            type: "POST",
            data: {"noteId":noteId},
            success: function (result) {
                $('h4#Title').text(result.name);
                $('p#Category').text(result.category);
                $('input#TimeOfCreate').val(result.timeOfCreate);
                $('input#TimeOfUpdate').val(result.timeOfUpdate);
                $('textarea#Description').val(result.description)
            }
        });
    });
});

/**
 * При вызове переходит в представление добавления и редактирования задачи.
 */
$(function () {
    $('button#AddButton').on('click', function (e) {
        window.location.href = window.location.origin + "/Home/AddEditNote/";
    });
});

/**
 * При вызове переходит в главное представление.
 */
$(function () {
    $('button#CancelAddNoteButton').on('click', function (e) {
        window.location.href = window.location.origin;
    });
});

/**
 * При вызове переходит в представление редактирования задачи.
 */
$(function () {
    $('button#EditButton').on('click', function (e) {
        var noteId = $('select#NotesListBox').val();
        window.location.href = window.location.origin + '/Home/AddEditNote?noteId=' + noteId;
    });
});

/**
 * При вызове удаляет выбранный элемент списка.
 */
$(function () {
    $('button#RemoveButton').on('click', function (e) {
        e.preventDefault();
        var noteId = $("select#NotesListBox").val();
        $.ajax({
            url: '/Home/RemoveNote/',
            type: "POST",
            data: {"noteId":noteId},
            success: function (result)
            {
                window.location.href = window.location.href;
            }
        });
    });
});

/**
 * При вызове обновляет данные в ListBox.
 */
$(function () {
    $('select#CategoryComboBox').change(function () {
        var categoryId = $(this).val();
        console.log(categoryId);
        $.ajax({
            url: '/Home/LoadSelectedCategoryNotes/',
            type: "POST",
            data: {"category":categoryId},
            success: function (result) {
                $('select#NotesListBox').empty();
                $.each(result.items, function (index, note)
                {
                    $('select#NotesListBox').append($("<option></option>").attr("value", note.id).text(note.title));
                });
                $('h4#Title').text("Title");
                $('p#Category').empty();
                $('input#TimeOfCreate').val("");
                $('input#TimeOfUpdate').val("");
                $('textarea#Description').val("");
            }
        });
    });
});