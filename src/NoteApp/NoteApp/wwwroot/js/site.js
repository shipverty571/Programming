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
                console.log(result);
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
 * При вызове переходит в представление добавления задачи.
 */
$(function () {
    $('button#AddButton').on('click', function (e) {
        window.location.href = window.location.origin + "/Home/EditNote/";
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
 * При вызове добавляет заметку в базу данных.
 */
$(function () {
    $('button#AddNoteButton').on('click', function (e) {
        var name = $('input#Name').val();
        var category = $('select#Category').val();
        var description = $('textarea#Description').val();
        var id = $("div.main").attr('id');
        console.log(name);
        console.log(category);
        console.log(description);
        console.log(id);
        $.ajax({
            url: '/Home/Index/',
            type: "POST",
            data: {
                "Id": id,
                "Name": name,
                "Category": category,
                "Description": description
            },
            success: function (result) {
                window.location.href = window.location.origin;
            }
        });
    });
});

/**
 * При вызове переходит в представление редактирования задачи.
 */
$(function () {
    $('button#EditButton').on('click', function (e) {
        var noteId = $('select#NotesListBox').val();
        window.location.href = window.location.origin + '/Home/EditNote?noteId=' + noteId;
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
