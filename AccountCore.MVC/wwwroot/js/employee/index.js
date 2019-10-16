var dataTableEmployees;
var employeeEntity = 'Employee';
var apiEmployeeUrl = '/api/' + employeeEntity;
var gridEmployee = '#grid-employees';

$(document).ready(function () {
    bindEmployees(gridEmployee);
});

function bindEmployees(gridId) {
    var columns = [];
    columns.push({ "data": "name" });
    columns.push({ "data": "salaryPerHour" });
    columns.push({ "data": "managerName" });
    columns.push({ "data": "position" });
   
    columns.push({
        "data": { personId: "personId" },
        "render": function (data) {
            var btnEdit = "<a href='/Employee/Edit?id=" + data.personId + "' class='btn btn-default btn-xs' title='Edit'><i class='fa fa-pencil'></i></a>";
            var btnDelete = "<a class='btn btn-danger btn-xs' style='margin-left:2px' onclick=DeleteEmployee('" + data.personId + "') title='Delete'><i class='fa fa-trash'></i></a>";
            return btnEdit + btnDelete;
        }
    });

    var baseCommonSettings = {
        "dom": '<"pull-left"f><"pull-right"l>tip',
        "ajax": {
            "url": apiEmployeeUrl,
            "type": 'GET',
            "datatype": 'json'
        },
        "columns": columns,
        "language": {
            "emptyTable": "no data found."
        },
        "processing": true,
        "serverSide": true,
        "pagingType": "full_numbers",
        "ordering": false
    };

    var popupExtraSettings = {
        "pageLength": 10,
        "bLengthChange": false
    };

    dataTableEmployees = $(gridId).DataTable({ ...baseCommonSettings, ...popupExtraSettings });
}

function DeleteEmployee(id) {
    swal({
        title: "Are you sure want to Delete?",
        text: "Are you sure want to Delete?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#dd4b39",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: true
    },
        function () {
            $.ajax({
                type: 'DELETE',
                url: apiEmployeeUrl + '/' + id,
                success: function (data) {
                    if (data.success) {
                        ShowMessage(data.message);
                        dataTableEmployees.ajax.reload();
                    } else {
                        ShowMessageError(data.message);
                    }
                }
            });
        });
}

function ShowMessage(msg) {
    toastr.success(msg);
}