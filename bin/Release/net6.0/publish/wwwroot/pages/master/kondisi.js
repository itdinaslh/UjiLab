$(document).ready(function () {
    loadTable();
});

function loadContent() {
    loadTable();
}

function loadTable() {
    $('#tblData').DataTable().destroy();
    $('#tblData').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        stateSave: true,
        lengthMenu: [5, 10, 20],
        ajax: {
            url: '/api/master/kondisi',
            method: 'POST'
        },
        columns: [
            { data: 'kondisiID', name: 'kondisiID', autowidth: true },            
            { data: 'namaKondisi', name: 'namaKondisi', autowidth: true },
            {
                data: 'kondisiID',                
                render: function (data, type, row) {
                    return "<button class='btn btn-sm btn-success mr-2 showMe' data-href='/master/kondisi/edit/?id="
                        + row.kondisiID + "'><i class='ri-edit-box-line'></i></button>";
                },
                orderable: false,
            }
        ],
        columnDefs: [
            {
                targets: [0, 2],
                className: 'text-center'
            }
        ],
        order: [[0, "desc"]]
    });
}