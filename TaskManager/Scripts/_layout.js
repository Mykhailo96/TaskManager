$(document).ready(function() {
    $('.reference').on('click', function (e) {
        e.preventDefault();
        var page = $(this).attr("href");
        $("#partialDiv").load(page);
    });
})