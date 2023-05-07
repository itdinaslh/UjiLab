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

    $('#FormTambahPengajuan').validate({
        rules: {
            JenisPengajuan: "required",
            TipePengajuan: "required",
            NamaContoh: "required",
            TipeLokasi: "required",
            PetugasSampling: "required",
            Wadah: "required",
            TanggalSampling: "required",
            WaktuSampling: "required",
            VolumeContoh: "required",
            MetodeSampling: "required",
            Pengawetan: "required",
            Latitude: "required",
            Longitude: "required",
            OutputHasilID: "required",
            BakuMutuID: "required",
            BadanAir: "required",
            NamaSungai: "required"
        },
        messages: {
            JenisPengajuan: 'Pilih jenis pengajuan...',
            TipePengajuan: 'Pilih tipe pengajuan...',
            NamaContoh: 'Nama Contoh Uji wajib diisi...',
            TipeLokasi: 'Pilih tipe lokasi',
            PetugasSampling: 'Isi petugas sampling',
            Wadah: 'Harap isi wadah..',
            TanggalSampling: 'Pilh tanggal sampling',
            WaktuSampling: 'Pilih waktu sampling',
            VolumeContoh: 'Isi volume contoh',
            MetodeSampling: 'Pilih metode sampling',
            Pengawetan: 'Isi jenis pengawetan',
            Latitude: 'Isi latitude',
            Longitude: 'Isi longitude',
            OutputHasilID: 'Pilih output hasil uji',
            BakuMutuID: 'Pilih baku mutu',
            BadanAir: 'Pilih badan air',
            NamaSungai: 'Isi detail lokasi'

        },
        errorElement: "em",
        errorPlacement: function (error, element) {
            // Add the `invalid-feedback` class to the error element
            error.addClass("invalid-feedback");

            if (element.prop("type") === "checkbox") {
                error.insertAfter(element.next("label"));
            } if (element.hasClass('web-select2')) {
                error.insertAfter(element.next('.select2-container')).addClass('mt-2 text-danger');
            } else {
                error.insertAfter(element);
            }
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass("is-invalid").removeClass("is-valid");
            $(element).addClass('form-control-danger');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).addClass("is-valid").removeClass("is-invalid");
        },
        submitHandler: function (form, e) {
            e.preventDefault();
            SubmitDetail();
            ResetDetailUji();
        }
    });
});

function ResetDetailUji() {
    $('.web-select2').val(null).trigger('change');
    $('#FormTambahPengajuan')[0].reset();
    $('.is-invalid').removeClass('is-invalid');
    $('.is-valid').removeClass('is-valid');
    $('.error').removeClass('error');
    clearTable();
}

$('#TipeLokasi').change(function () {
    $('#TipeLokasi-error').remove();
});

$('#MetodeSampling').change(function () {
    $('#MetodeSampling-error').remove();
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

function SubmitDetail() {   

    const jns = $('#JenisPengajuan').val();
    const jnsName = $('#JenisPengajuan option:selected').text();
    const type = $('#TipePengajuan').val();
    const typeName = $('#TipePengajuan option:selected').text();
    const typeLokasi = $('#TipeLokasi option:selected').text();
    const tglSampling = $('#TanggalSampling').val();
    const timeSampling = $('#WaktuSampling').val();
    const status = 'Draft';
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
}

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

