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
            { data: 'namaClient', name: 'namaClient', autowidth: true, orderable: false },
            { data: 'createdAt', name: 'createdAt', autowidth: true, searchable: false, orderable: false },                                    
            { data: 'namaTipe', name: 'namaTipe', autowidth: true, orderable: false, searchable: false },
            {
                data: 'statusName',
                render: function (data, type, row) {
                    return "<span class='text-bg-success p-2'>" + row.statusName + "</span>";
                }                
            },
            {
                data: 'clientID',
                render: function (data, type, row) {
                    return "<a class='btn btn-sm btn-danger mr-2' href='/clients/verify/?id="
                        + row.clientID + "'><i class='ri-edit-box-line'></i></a>";
                },
                orderable: false,                
            }
        ]        
    });
}