var baku = '';
var tblNum = 0;
var totalBiayaUji = 0;
var totalBiayaAlat = 0;
var uji = [];
var allBiayaUji = 0;
var allBiayaAlat = 0;
var main = 1;
var currentModul = 1;

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

$('.timepick').flatpickr({
    enableTime: true,
    noCalendar: true,
    dateFormat: "H:i",
    time_24hr: true,
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

function drawTable(data) {
    clearTable();

    $("#tblParameter tr:has(td)").remove();

    var trHTML = ''; var trFoot = '';

    $.each(data, function (i, item) {
        trHTML += '<tr id="row' + tblNum + '"><td class="text-center">' + (tblNum + 1) + '</td><td class="text-center">'
            + item.namaParameter + '</td><td class="text-center">' + item.satuan + '</td><td class="text-center">'
            + item.namaMetode + '</td><td class="text-center">' + 'Rp ' + item.biayaUji.toLocaleString('id-ID')
            + '</td><td class="text-center">' + 'Rp ' + item.biayaAlat.toLocaleString('id-ID')
            + '</td><td class="text-center">' + '<button class="btn btn-sm btn-danger delBtn" data-id="' + tblNum + '">' + '<i class="ri-delete-bin-6-line"></i></button>'
            + '</td></tr>';

        totalBiayaUji += item.biayaUji;
        totalBiayaAlat += item.biayaAlat;

        tblNum += 1;
    });

    trFoot += '<tr><td colspan="7" class="text-end">Total Biaya Uji : Rp <span id="txtBiayaUji">' + totalBiayaUji.toLocaleString('id-ID') + '</span></td></tr>';
    trFoot += '<tr><td colspan="7" class="text-end">Total Biaya Alat : Rp <span id="txtBiayaAlat">' + totalBiayaAlat.toLocaleString('id-ID') + '</span></td></tr>';
    trFoot += '<tr><td colspan="7" class="text-end">Total Keseluruhan : Rp <span id="txtKeseluruhan">' + (totalBiayaUji + totalBiayaAlat).toLocaleString('id-ID') + '</span></td></tr>';

    $('#tblParameter').append(trHTML);
    $('#tblParameter').append(trFoot);
}

function drawMainTable(data) {
    $("#mainTable tr:has(td)").remove();
    main = 1;

    var trHTML = ''; var trFoot = '';

    $.each(data, function (i, item) {
        trHTML += '<tr id="main' + main + '" class="text-center"><td>' + '</td><td>'
            + item.NamaContohUji + '</td><td>'
            + item.TipeLokasi + '</td><td>'
            + item.TglSampling + ' ' + item.WaktuSampling + '</td><td>'
            + item.OutputHasil + '</td><td>'
            + 'Rp ' + item.BiayaUji.toLocaleString('id-ID') + '</td><td>'
            + 'Rp ' + item.BiayaAlat.toLocaleString('id-ID') + '</td><td>'
            + item.Status + '</td><td>'
            + '<button class="btn btn-primary btn-sm editBtn" data-id="' + main + '"><i class="ri-edit-line"></i></button>'
            + '</td></tr>';
    });

    trFoot += '<tr><td colspan="9" class="text-end">Estimasi Total Biaya Uji : Rp <span class="MainBiayaUji">' + '</span></td></tr>';
    trFoot += '<tr><td colspan="9" class="text-end">Estimasi Total Biaya Alat : Rp <span class="MainBiayaAlat">' + '</span></td></tr>';
    trFoot += '<tr><td colspan="9" class="text-end">Estimasi Total Keseluruhan : Rp <span class="MainBiayaKeseluruhan">' + '</span></td></tr>';

    $('#mainTable').append(trHTML);
    $('#mainTable').append(trFoot);
}

function clearTable() {
    // remove all existing rows
    $("#tblParameter tr:has(td)").remove();
    tblNum = 0;
    totalBiayaUji = 0;
    totalBiayaAlat = 0;

    var trHTML = '';

    trHTML += '<tr><td colspan="7" class="text-center">Tidak ada data</td></tr>';

    $('#tblParameter').append(trHTML);
}

$(document).on('click', '.delBtn', function () {
    var thisID = $(this).attr('data-id');

    baku.splice(thisID, 1);

    $('#row' + thisID).remove();

    drawTable(baku);
    
});

$('#btnSave').click(function () {
    const jns = $('#JenisPengajuan').val();
    const jnsName = $('#JenisPengajuan option:selected').text();
    const type = $('#TipePengajuan').val();
    const typeName = $('#TipePengajuan option:selected').text();
    const typeLokasi = $('#TipeLokasi option:selected').text();
    const tglSampling = $('#TanggalSampling').val();
    const timeSampling = $('#WaktuSampling').val();
    const status = 'New';
    const ujiName = $('#NamaContoh').val();
    const output = $('#OutputHasilID option:selected').text();
    const param = baku;

    const data = {
        jenis: jns,
        tipe: type,
        TipeLokasi: typeLokasi,
        OutputHasil: output,
        BiayaUji: totalBiayaUji,
        BiayaAlat: totalBiayaAlat,
        TglSampling: tglSampling,
        WaktuSampling: timeSampling,
        NamaContohUji: ujiName,
        Status: status,
        StatusID: 1,
        parameters: param
    };

    uji.push(data);

    drawMainTable(uji);

    SumAllBiaya(uji);

    ChangeView(1);
});

function SumAllBiaya(data) {
    allBiayaUji = 0;
    allBiayaAlat = 0;

    $.each(data, function (i, item) {
        $.each(item.parameters, function (x, row) {
            allBiayaUji += row.biayaUji;
            allBiayaAlat += row.biayaAlat;
        })
    });

    $('.MainBiayaUji').text(allBiayaUji.toLocaleString("id-ID"));
    $('.MainBiayaAlat').text(allBiayaAlat.toLocaleString("id-ID"));
    $('.MainBiayaKeseluruhan').text((allBiayaUji + allBiayaAlat).toLocaleString("id-ID"));
}


function ChangeView(val) {
    $('#modul' + currentModul).hide("fast");
    currentModul = val;

    $('#modul' + val).show("fast");
}

