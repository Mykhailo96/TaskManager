
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
            {
                data: "deadline",
                render: function (data, type, task) {
                    return "<img align='right' class='js-delete' data-task-id=" + task.id + " src='../../Content/delete.png' alt='Delete' width='20'/>";
                }
            }
        ]
    });

    $("#tasks").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this task?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/tasks/" + button.attr("data-task-id"),
                    method: "DELETE",
                    success: function () {
                        toastr.success("Task successfully deleted.");
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });
});