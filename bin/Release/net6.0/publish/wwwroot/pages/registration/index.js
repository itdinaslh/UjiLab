$(document).ready(function () {
    PopulateTipeUsaha();
    PopulateBidangUsaha();
    PopulateProvinsi();
    PopulateKabupaten();
});


function PopulateTipeUsaha() {
    $('#sTipeUsaha').select2({
        placeholder: 'Pilih Tipe Usaha...',
        allowClear: true,
        ajax: {
            url: "/api/master/tipe-usaha/search",
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

function PopulateBidangUsaha() {
    $('#sBidangUsaha').select2({
        placeholder: 'Pilih Bidang Usaha...',
        allowClear: true,
        ajax: {
            url: "/api/master/bidang-usaha/search",
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