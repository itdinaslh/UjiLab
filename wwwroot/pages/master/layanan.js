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
            url: '/api/master/layanan',
            method: 'POST'
        },
        columns: [
            { data: 'layananID', name: 'layananID', autowidth: true },
            { data: 'namaLayanan', name: 'namaLayanan', autowidth: true },
            {
                data: 'layananID',                
                render: function (data, type, row) {
                    return "<button class='btn btn-sm btn-success mr-2 showMe' data-href='/master/layanan/edit/?id="
                        + row.layananID + "'><i class='ri-edit-box-line'></i></button>";
                },
                orderable: false
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