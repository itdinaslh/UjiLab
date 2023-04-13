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
            url: '/api/master/metode-sampling',
            method: 'POST'
        },
        columns: [
            { data: 'metodeSamplingID', name: 'metodeSamplingID', autowidth: true },
            { data: 'namaMetode', name: 'namaMetode', autowidth: true },
            { data: 'kode', name: 'kode', autowidth: true },
            { data: 'deskripsi', name: 'deskripsi', autowidth: true },
            {
                data: 'metodeSamplingID',                
                render: function (data, type, row) {
                    return "<button class='btn btn-sm btn-success mr-2 showMe' data-href='/master/metode-sampling/edit/?metodeSamplingID="
                        + row.metodeSamplingID + "'><i class='ri-edit-box-line'></i></button>";
                },
                orderable: false
            }
        ],
        columnDefs: [
            {
                targets: [0, 4],
                className: 'text-center'
            }
        ],
        order: [[0, "desc"]]
    });
}