$(document).on('select2:open', () => {
    document.querySelector('.select2-search__field').focus();
});

$(document).ready(function () {
    loadTable();
    $('.autonumber').autoNumeric('init', { currencySymbol: 'Rp. ', allowDecimalPadding: false, digitGroupSeparator: '.', decimalCharacter: ',' });
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
            url: '/api/master/parameter',
            method: 'POST'
        },
        columns: [
            { data: 'parameterID', name: 'parameterID', autowidth: true },
            { data: 'namaParameter', name: 'namaParameter', autowidth: true },
            { data: 'satuan', name: 'satuan', autowidth: true, orderable: false },
            { data: 'biayaUji', name: 'biayaUji', autowidth: true, orderable: false },
            { data: 'biayaAlat', name: 'biayaAlat', autowidth: true, orderable: false },
            { data: 'namaJenis', name: 'namaJenis', autowidth: true, orderable: false },
            {
                data: 'parameterID',
                render: function (data, type, row) {
                    return "<button class='btn btn-sm btn-success mr-2 showMe' alt='Edit' data-href='/master/parameter/edit/?id="
                        + row.parameterID + "'><i class='ri-edit-box-line'></i></button>";
                }
            }
        ],
        columnDefs: [
            {
                targets: [0, 2, 3, 4, 5, 6],
                className: 'text-center'
            }
        ],
        order: [[0, "desc"]]
    });
}

$(document).on('shown.bs.modal', function () {
    $('.autonumber').autoNumeric('init', { currencySymbol: 'Rp. ', allowDecimalPadding: false, digitGroupSeparator: '.', decimalCharacter: ',' });
    $('#biayaUji').autoNumeric('set', $('.rBiayaUji').val());
    $('#biayaAlat').autoNumeric('set', $('.rBiayaAlat').val());
});

$(document).on('keyup', '#biayaUji', function () {
    var jumlah = $(this).autoNumeric('get');
    $('.rBiayaUji').val(jumlah);
});

$(document).on('keyup', '#biayaAlat', function () {
    var jumlah = $(this).autoNumeric('get');
    $('.rBiayaAlat').val(jumlah);
});