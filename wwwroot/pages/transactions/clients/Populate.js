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
    }).on('change', function () {
        $('.sBakuMutu').val(null).trigger('change');
        var theID = $('.sOutputHasil option:selected').val();
        PopulateBakuMutu(theID);
        clearTable();
        $('.sBakuMutu').select2('focus');
    });
}

function PopulateBakuMutu(output) {
    $('.sBakuMutu').select2({
        placeholder: 'Pilih baku mutu...',
        allowClear: true,
        ajax: {
            url: "/api/master/baku-mutu/jenis/search?outputID=" + output,
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
        var theID = $('.sBakuMutu option:selected').val();
        $.ajax({
            type: 'GET',
            url: '/api/master/baku-mutu/table-data/?jenisID=' + theID,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                baku = data;
                drawTable(baku);
            }
        });
    });
}