var dataTable;

$(document).ready(function () {
    loadData();
});

function loadData() {
    dataTable = $('#tblTable').DataTable({
        "ajax": { url: '/user/workoutplan/getall' },
        "columns": [
            { data: 'date', "width": "20%" },
            { data: 'notes', "width": "40%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class = "w-75 btn-group" role="group">
                        <a href="/user/workoutplan/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit </a>
                        <a onClick=Delete('/user/workoutplan/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash3-fill"></i>Delete</a>
                        <a href="/user/workoutdetails/index?id=${data}" class="btn btn-primary mx-2 <i class="bi bi-book"></i> Details</a>
                    </div>`
                },
                "width": "40%"
            }
        ]
    });
}

function Delete (url){
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}