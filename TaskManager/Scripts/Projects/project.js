function myFunction(item) {
    var table = $("#tasksTable").DataTable({
        data: item,
        info: false,
        paging: false,
        order: [[ 3, "asc" ]],
        columns: [
            {
                data: "name",
                render: function (data, type, task) {
                    return "<a align='left' href='/tasks/task/" + task.id + "'>" + task.name + "</a>";
                }
            },
            { data: "status.name" },
            { data: "priority.name" },
            {
                data: "deadline",
                render: function (data, type, task) {
                    return data + "<img class='js-delete' align='right' data-task-id=" + task.id + " src='../../Content/delete.png' alt='Delete' width='20'/>";
                }
            }
        ]
    });

    $("#tasksTable").on("click", ".js-delete", function () {
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
}