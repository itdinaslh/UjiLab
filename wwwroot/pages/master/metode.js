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
                "render": function (data, type, row) {
                    return "<button class='btn btn-sm btn-success mr-2 showMe' style='width:100%;' data-href='/master/metode-sampling/edit/?metodeSamplingID="
                        + row.layananID + "'><i class='fa fa-edit'></i> Edit</button>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}