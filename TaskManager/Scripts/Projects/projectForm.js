var vm = {
    Name: ""
}

$(document).ready(function () {
    $("#newProject").on("click", function (e) {
        e.preventDefault();

        vm.Name = $("#pr-name").val();

        $.ajax({
            url: "/api/projects",
            type: "POST",
            data: vm,
        })
        .done(function() {
            toastr.success("Project successfully added.");
            $("#pr-name").val("");
            vm = { Name: "" };
        })
        .fail(function() {
            toastr.error("Something wrong.");
        })
    });
});