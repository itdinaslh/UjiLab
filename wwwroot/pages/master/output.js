$(document).on('select2:open', () => {
    document.querySelector('.select2-search__field').focus();
});

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
            url: '/api/master/output-hasil',
            method: 'POST'
        },
        columns: [
            { data: 'outputHasilID', name: 'outputHasilID', autowidth: true },
            { data: 'outputName', name: 'outputName', autowidth: true },
            { data: 'kode', name: 'kode', autowidth: true, orderable: false },
            { data: 'namaTipe', name: 'namaTipe', autowidth: true },
            {
                data: 'outputHasilID',
                render: function (data, type, row) {
                    return "<button class='btn btn-sm btn-success mr-2 showMe' alt='Edit' data-href='/master/output-hasil/edit/?id="
                        + row.outputHasilID + "'><i class='ri-edit-box-line'></i></button>";
                }
            }
        ],
        columnDefs: [
            {
                targets: [0,2,4],
                className: 'text-center'
            }
        ],
        order: [[0, "desc"]]
    });
}

$(document).on('shown.bs.modal', function () {
    $('#sTipe').select2({
        placeholder: 'Pilih Tipe Pengajuan...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/master/pengajuan/tipe/search",
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var query = {
                    term: params.term,
                };
                return query;
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
                        return {
                            text: item.data,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
});