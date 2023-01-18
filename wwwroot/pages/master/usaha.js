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
                "render": function (data, type, row) {
                    return "<button class='btn btn-sm btn-success mr-2 showMe' style='width:100%;' data-href='/master/layanan/edit/?layananID="
                        + row.layananID + "'><i class='fa fa-edit'></i> Edit</button>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}