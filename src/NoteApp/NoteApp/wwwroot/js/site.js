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
