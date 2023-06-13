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
            url: '/api/master/baku-mutu',
            method: 'POST'
        },
        columns: [
            { data: 'bakuMutuID', name: 'bakuMutuID', autowidth: true },
            { data: 'jenisPengajuan', name: 'jenisPengajuan', autowidth: true },
            { data: 'tipePengajuan', name: 'tipePengajuan', autowidth: true },  
            { data: 'outputHasil', name: 'outputHasil', autowidth: true, orderable: false, searchable: false },
            { data: 'metodeParameter', name: 'metodeParameter', autowidth: true },
            { data: 'jenisBakuMutu', name: 'jenisBakuMutu', autowidth: true },
            { data: 'parameter', name: 'parameter', autowidth: true },
            { data: 'biayaUji', name: 'biayaUji', autowidth: true, orderable: false, searchable: false },
            { data: 'biayaAlat', name: 'biayaAlat', autowidth: true, orderable: false, searchable: false },
            {
                data: 'bakuMutuID',
                render: function (data, type, row) {
                    return "<button class='btn btn-sm btn-success mr-2 showMe' alt='Edit' data-href='/master/baku-mutu/edit/?id="
                        + row.bakuMutuID + "'><i class='ri-edit-box-line'></i></button>";
                },
                orderable: false, searchable: false
            }
        ],
        columnDefs: [
            {
                targets: [0, 7,8,9],
                className: 'text-center'
            }
        ],
        order: [[0, "desc"]]
    });
}

$(document).on('shown.bs.modal', function () {
    $('.autonumber').autoNumeric('init', { currencySymbol: 'Rp. ', allowDecimalPadding: false, digitGroupSeparator: '.', decimalCharacter: ',' });

    PopulateJenisBakuMutu();
    PopulateMetodeParameter();
    PopulateParameter();

    $('.sJenisPengajuan').select2({
        placeholder: 'Pilih Jenis Pengajuan...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/master/pengajuan/jenis/search",
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
    }).on('change', function () {
        $('.sTipePengajuan').val(null).trigger('change');
        var theID = $('.sJenisPengajuan option:selected').val();
        PopulateTipePengajuan(theID);
        $('.sTipePengajuan').select2('focus');
    });

    $('.sTipePengajuan').select2({
        placeholder: 'Pilih jenis terlebih dahulu...',
        dropdownParent: $('#myModal'),
    });

    $('.sOutputHasil').select2({
        placeholder: 'Pilih tipe pengajuan terlebih dahulu...',
        dropdownParent: $('#myModal'),
    });
});

function PopulateTipePengajuan(jenis) {
    $('.sTipePengajuan').select2({
        placeholder: 'Pilih tipe pengajuan...',
        dropdownParent: $('#myModal'),        
        allowClear: true,
        ajax: {
            url: "/api/master/pengajuan/tipe/searchbyjenis?jenis=" + jenis,
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
    }).on('change', function () {
        $('.sOutputHasil').val(null).trigger('change');
        var theID = $('.sTipePengajuan option:selected').val();
        PopulateOutputHasil(theID);
        $('.sOutputHasil').select2('focus');
    });
}

function PopulateOutputHasil(tipe) {
    $('.sOutputHasil').select2({
        placeholder: 'Pilih output hasil...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/master/output-hasil/searchbytipe?tipe=" + tipe,
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
}

function PopulateJenisBakuMutu() {
    $('.sJenisBakuMutu').select2({
        placeholder: 'Pilih jenis baku mutu...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/master/baku-mutu/jenis/search",
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
}

function PopulateMetodeParameter() {
    $('.sMetodeParameter').select2({
        placeholder: 'Pilih metode parameter...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/master/metode-parameter/search",
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
}

function PopulateParameter() {
    $('.sParameter').select2({
        placeholder: 'Pilih parameter...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/master/parameter/search",
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
    }).on('change', function () {        
        var theID = $('.sParameter option:selected').val();
        GetPrice(theID);
    });
}

function GetPrice(id) {
    var uji, alat;

    $.ajax({
        url: '/api/master/parameter/getpricebyid/?id=' + id,
        dataType: 'json',
        method: 'GET',
        success: function (response) {
            uji = response.biayaUji;
            alat = response.biayaAlat;

            $('#biayaUji').autoNumeric('set', uji);
            $('#biayaAlat').autoNumeric('set', alat);

            $('.rBiayaUji').val(uji);
            $('.rBiayaAlat').val(alat);
        }
    });
}