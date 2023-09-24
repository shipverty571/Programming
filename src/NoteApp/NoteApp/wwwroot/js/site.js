// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
$(function () {
    $('select#NotesListBox').change(function () {
        var noteId = $(this).val();

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

$(function () {
    $('button#AddButton').on('click', function (e) {
        window.location.href = window.location.origin + "/Home/EditNote/";
    });
});

$(function () {
    $('button#CancelAddNoteButton').on('click', function (e) {
        window.location.href = window.location.origin + "/Home/Index/";
    });
});

$(function () {
    $('button#AddNoteButton').on('click', function (e) {
        var name = $('input#Name').val();
        var category = $('select#Category').val();
        var description = $('textarea#Description').val();
        console.log(name);
        console.log(category);
        console.log(description);
        $.ajax({
            url: '/Home/Index/',
            type: "POST",
            data: {
                "name": name,
                "category": category,
                "description": description
            },
            success: function (result) {
                window.location.href = window.location.origin;
            }
        });
    });
});
