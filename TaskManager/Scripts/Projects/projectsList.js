$(document).ready(function () {
    var table = $("#projects").DataTable({
        bSort: true,
        ajax: {
            url: "/api/projects",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                        render: function(data, type, project) {
                            return "<a align='left' href='/projects/project/" + project.id + "'>" + project.name + "</a><img align='right' class='js-delete'data-project-id=" + project.id + " src='../../Content/delete.png' alt='Delete' width='20'/>";
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