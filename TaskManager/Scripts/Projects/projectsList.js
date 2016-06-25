$(document).ready(function () {
    var table = $("#projects").DataTable({
        bSort: false,
        ajax: {
            url: "/api/projects",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                        render: function(data, type, project) {
                            return "<a href='/projects/project/" + project.id + "'>" + project.name + "</a>";
                        }
            },
            {
                data: "id",
                render: function (data) {
                    return "<img class='js-delete'data-project-id=" + data + " src='../../Content/delete.png' alt='Delete' width='20'/>";
                }
            }
        ]
    });


    $("#projects").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this project?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/projects/" + button.attr("data-project-id"),
                    method: "DELETE",
                    success: function () {
                        toastr.success("Project successfully deleted.");
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });
});