$(document).ready(function () {
    PopulateJenisPengajuan();
    $('.sTipePengajuan').select2({
        placeholder: 'Pilih jenis terlebih dahulu...'
    });
    PopulateMetodeSampling();
    PopulateTipeLokasi();
});

$('.datepick').flatpickr({
    dateFormat: 'd-m-Y',
    position: 'below'
});

function PopulateJenisPengajuan() {
    $('.sJenisPengajuan').select2({
        placeholder: 'Pilih jenis pengajuan...',
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
}

function PopulateTipePengajuan(jenis) {
    $('.sTipePengajuan').select2({
        placeholder: 'Pilih tipe pengajuan...',
        allowClear: true,
        ajax: {
            url: "/api/master/pengajuan/tipe/search?jenis=" + jenis,
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

function PopulateMetodeSampling() {
    $('.sMetodeSampling').select2({
        placeholder: 'Pilih metode sampling...',
        allowClear: true,
        ajax: {
            url: "/api/master/metode-sampling/search",
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

function PopulateTipeLokasi() {
    $('.sTipeLokasi').select2({
        placeholder: 'Pilih tipe lokasi..',
        allowClear: true,
        ajax: {
            url: "/api/master/tipe-lokasi/search",
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