$(document).ready(function () {
    loadTable();
});

function loadContent() {
    loadTable();
}

function loadTable() {
    $('#tblData').DataTable().clear().destroy();
    $('#tblData').DataTable({
        processing: false,
        serverSide: true,
        lengthMenu: [5, 10, 25, 50],
        filter: true,
        stateSave: true,
        orderMulti: false,
        ajax: {
            url: "/api/wilayah/kelurahan",
            type: "POST",
            dataType: "json"
        },
        columns: [
            { data: "kelurahanID", name: "kelurahanID", autoWidth: true },
            { data: "namaKelurahan", name: "namaKelurahan", autoWidth: true },
            { data: "namaKecamatan", name: "namaKecamatan", autoWidth: true },
            { data: "namaKabupaten", name: "namaKabupaten", autoWidth: true },
            { data: "namaProvinsi", name: "namaProvinsi", autoWidth: true }
        ],
        order: [[0, "desc"]]
    })
}