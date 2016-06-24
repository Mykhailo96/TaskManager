var vm = {
    Name: ""
}

$(document).ready(function () {
    var validator = $("#formId").validate({
        submitHandler: function () {

            vm.Name = $("#pr-name").val();

            $.ajax({
                url: "/api/projects/",
                type: "POST",
                data: vm,
            })
            .done(function () {
                toastr.success("Project successfully added.");
                $("#newProject").val("");
                vm.Name = "";

                validator.resetForm();
            })
            .fail(function () {
                toastr.error("Something wrong.");
            })
        }
    });
}   );