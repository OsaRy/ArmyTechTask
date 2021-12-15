var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#QualTable').DataTable({
        "ajax": {
            "url": "/Qualifications/GetAll",
            "data": { id:$("#addqualbtn").attr('emp')},
            "dataSrc": ''

        },
        "columns": [
            { "data": "ID", "width": "30%" },
            { "data": "Name", "width": "30%" },
           
            {
                "data": "ID",
                "render": function (data) {
                    return `
                            <div class="text-center">
                              
                                <a onclick=Add("/Employees/AddQualToEmp?id=${data}") class="btn btn-success text-white" style="cursor:pointer">
                                  اضافة
                                </a>
                            </div>
                           `;
                }, "width": "30%"
            }
        ]
    });

  
}
function Add(url) {
    swal({
        title: "هل انت متأكد؟",
        text: "هل انت متأكد من اضافة هذا المؤهل الي الموظف?",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willPOST) => {
        if (willPOST) {
            $.ajax({
                type: "POST",
                url: url + "&emp=" + $("#addqualbtn").attr('emp'),
                success: function (data) {
                    if (data.success)
                        location.reload();
                    else alert("حدث خطأ")
                }
            });
        }
    });
}
function Delete(url) {
    swal({
        title: "هل انت متأكد؟",
        text: "هل انت متأكد من مسح هذا المؤهل من الموظف?",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDELETE) => {
        if (willDELETE) {
            $.ajax({
                type: "POST",
                url: url + "&emp=" + $("#addqualbtn").attr('emp'),
                success: function (data) {
                    if (data.success)
                            location.reload();
                        else alert("حدث خطأ")
                   
                }
            });
        }
    });
}