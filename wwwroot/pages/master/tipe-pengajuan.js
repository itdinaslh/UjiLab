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
            url: '/api/master/pengajuan/tipe',
            method: 'POST'
        },
        columns: [
            { data: 'tipePengajuanID', name: 'tipePengajuanID', autowidth: true },
            { data: 'namaTipe', name: 'namaTipe', autowidth: true },
            { data: 'namaJenis', name: 'namaJenis', autowidth: true },
            {
                data: 'tipePengajuanID',
                render: function (data, type, row) {
                    return "<button class='btn btn-sm btn-success mr-2 showMe' alt='Edit' data-href='/master/pengajuan/tipe/edit/?id="
                        + row.tipePengajuanID + "'><i class='ri-edit-box-line'></i></button>";
                }
            }
        ],
        columnDefs: [
            {
                targets: 3,
                className: 'text-center'
            }
        ],
        order: [[0, "desc"]]
    });
}