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
            url: '/api/master/bidang-usaha',
            method: 'POST'
        },
        columns: [
            { data: 'bidangUsahaID', name: 'bidangUsahaID', autowidth: true },
            { data: 'namaBidangUsaha', name: 'namaBidangUsaha', autowidth: true },
            {
                data: 'bidangUsahaID',
                render: function (data, type, row) {
                    return "<button class='btn btn-sm btn-success mr-2 showMe' data-href='/master/bidang-usaha/edit/?bidangUsahaID="
                        + row.bidangUsahaID + "'><i class='ri-edit-box-line'></i></button>";
                },
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