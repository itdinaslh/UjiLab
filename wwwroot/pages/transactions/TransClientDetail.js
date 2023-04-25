﻿var baku = '';
var tblNum = 1;
var totalBiayaUji = 0;
var totalBiayaAlat = 0;

$(document).ready(function () {
    PopulateJenisPengajuan();
    $('.sTipePengajuan').select2({
        placeholder: 'Pilih jenis terlebih dahulu...'
    });
    $('.sOutputHasil').select2({
        placeholder: 'Pilih tipe terlebih dahulu...'
    });
    $('.sBakuMutu').select2({
        placeholder: 'Pilih output hasil uji terlebih dahulu...'
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

function drawTable(data) {
    clearTable();

    $("#tblParameter tr:has(td)").remove();

    var trHTML = ''; var trFoot = '';

    $.each(data, function (i, item) {
        trHTML += '<tr id="row' + tblNum + '"><td class="text-center">' + tblNum + '</td><td class="text-center">'
            + item.namaParameter + '</td><td class="text-center">' + item.satuan + '</td><td class="text-center">'
            + item.namaMetode + '</td><td class="text-center">' + 'Rp ' + item.biayaUji.toLocaleString('id-ID')
            + '</td><td class="text-center">' + 'Rp ' + item.biayaAlat.toLocaleString('id-ID')
            + '</td><td class="text-center">' + '<button class="btn btn-sm btn-danger delBtn" data-id="' + tblNum + '">' + '<i class="ri-delete-bin-6-line"></i></button>'
            + '</td></tr>';

        totalBiayaUji += item.biayaUji;
        totalBiayaAlat += item.biayaAlat;

        tblNum += 1;
    });

    trFoot += '<tr><td colspan="7" class="text-end">Total Biaya Uji : Rp ' + totalBiayaUji.toLocaleString('id-ID');
    trFoot += '<tr><td colspan="7" class="text-end">Total Biaya Alat : Rp ' + totalBiayaAlat.toLocaleString('id-ID');
    trFoot += '<tr><td colspan="7" class="text-end">Total Keseluruhan : Rp ' + (totalBiayaUji + totalBiayaAlat).toLocaleString('id-ID');

    $('#tblParameter').append(trHTML);
    $('#tblParameter').append(trFoot);
}

function clearTable() {
    // remove all existing rows
    $("#tblParameter tr:has(td)").remove();
    tblNum = 1;
    totalBiayaUji = 0;
    totalBiayaAlat = 0;

    var trHTML = '';

    trHTML += '<tr><td colspan="7" class="text-center">Tidak ada data</td></tr>';

    $('#tblParameter').append(trHTML);
}

$(document).on('click', '.delBtn', function () {
    var thisID = $(this).attr('data-id');

    $('#row' + thisID).remove();
});