$(document).ready(function () {
    var table = $("#tasks").DataTable({
        ajax: {
            url: "/api/tasks",
            dataSrc: ""
        },
        columns: [
            { data: "name" },
            { data: "status.name" },
            { data: "priority.name" },
            { data: "deadline" }
        ]
    });
});