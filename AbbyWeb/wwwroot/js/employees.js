var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#employees').DataTable({
        'ajax': {
            'url': '/api/employees',
            'type': 'GET',
            'dataType': 'json',

        },
        'columns': [
            { 'data': 'fullName' },
            { 'data': 'firstName' },
            { 'data': 'lastName' },
            { 'data': 'address' },
            { 'data': 'telephone' },
            { 'data': 'salary' },
            { 'data': 'dob' },
            { 'data': 'gender' },
            { 'data': 'occupation' },
            {
                'data': 'id',
                'render': function (data) {
                    return `<div class="class="btn-group w-75" role="group">
                            <a href="/Employees/upsert?id=${data}" class="btn btn-primary form-control mx-2"
                            style="cursor:pointer;">
                               <i class="bi bi-pencil"></i>
                            </a>
                            <a class="btn btn-danger form-control mx-2"
                            style="cursor:pointer;" href="Employees/delete?id=${data}">
                               <i class="bi bi-trash"></i>
                            </a>
                            `;
                }, 'width': '30%'
            }
        ],
        'language': {
            'emptyTable': 'No data has been added yet!'
        },
        'width': '100%'
    });

}

function Delete(url) {
    swal({
        title: 'Are you sure you want to Delete?',
        text: 'You will not be able to restored the data!',
        icon: 'warning',
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }

            });
        }
    });
}
