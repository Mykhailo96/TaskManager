function myFunction(item) {
    $("#tasksTable").DataTable({
        data: item,
        info: false,
        paging: false,
        order: [[ 3, "asc" ]],
        columns: [
            { data: "name" },
            { data: "status.name" },
            { data: "priority.name" },
            { data: "deadline" }
        ]
    });
}