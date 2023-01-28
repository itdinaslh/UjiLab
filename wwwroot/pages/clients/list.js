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
            url: '/api/clients/list',
            method: 'POST'
        },
        columns: [
            { data: 'clientID', name: 'clientID', autowidth: true },
            { data: 'namaClient', name: 'namaClient', autowidth: true },
            { data: 'namaTipe', name: 'namaTipe', autowidth: true },
            {
                data: 'statusName',
                render: function (data, type, row) {
                    return "<span class='text-bg-success p-2'>" + row.statusName + "</span>";
                }
            },
            {
                data: 'clientID',
                render: function (data, type, row) {
                    return "<button class='btn btn-sm btn-success mr-2 showMe' data-href='/clients/details/verify/?id="
                        + row.clientID + "'><i class='fa fa-edit'></i> Edit</button>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}