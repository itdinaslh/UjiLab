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
            url: "/api/wilayah/kecamatan",
            type: "POST",
            dataType: "json"
        },
        columns: [
            { data: "kecamatanID", name: "kecamatanID", autoWidth: true },
            { data: "namaKecamatan", name: "namaKecamatan", autoWidth: true },
            { data: "namaKabupaten", name: "namaKabupaten", autoWidth: true },
            { data: "namaProvinsi", name: "namaProvinsi", autoWidth: true },
            { data: "latitude", name: "latitude", autoWidth: true },
            { data: "longitude", name: "longitude", autoWidth: true }
        ],
        order: [[0, "desc"]]
    })
}