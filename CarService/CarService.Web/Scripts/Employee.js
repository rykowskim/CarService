$('#fancy-checkbox-primary').on('change', function () {
    if (this.checked) {
        $('#@Html.IdFor(m => m.EmployeeIsAdministrator)').val(true);
    }
    else {
        $('#@Html.IdFor(m => m.EmployeeIsAdministrator)').val(false);
    }
});