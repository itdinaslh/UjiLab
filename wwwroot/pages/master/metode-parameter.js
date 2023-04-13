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
            url: '/api/master/metode-parameter',
            method: 'POST'
        },
        columns: [
            { data: 'metodeParameterID', name: 'metodeParameterID', autowidth: true },
            { data: 'namaMetode', name: 'namaMetode', autowidth: true, searchable: false, orderable: false },
            {
                data: 'metodeParameterID',
                render: function (data, type, row) {
                    return "<button class='btn btn-sm btn-success mr-2 showMe' data-href='/master/metode-parameter/edit/?id="
                        + row.metodeParameterID + "'><i class='ri-edit-box-line'></i></button>";
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