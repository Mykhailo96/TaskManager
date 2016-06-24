$(document).ready(function () {
    $.ajax({
        url: "/api/projects/" + @Model,
        type: "GET",
        success: function (data) {
            $("#task").append("<li class='list-group-item'>" + data.name + "</li>");
        },
        "error": function (data) {
            var response = data.responseText;
            alert('Error loading: ' + response);
        }
    });
});