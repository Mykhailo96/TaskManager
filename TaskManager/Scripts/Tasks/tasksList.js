$(document).ready(function () {
    var table = $("#tasks").DataTable({
        ajax: {
            url: "/api/tasks",
            dataSrc: ""
        },
        order: [[ 3, "asc" ]],
        columns: [
            { data: "name" },
            { data: "status.name" },
            { data: "priority.name" },
            { data: "deadline" }
        ]
    });
});