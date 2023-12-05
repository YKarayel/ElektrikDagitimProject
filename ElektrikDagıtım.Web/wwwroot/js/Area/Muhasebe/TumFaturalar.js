//Admin'e özel oluşturulmuş sayfa!!
//Fatura create, delete(aktif=false), update

$(document).ready(function () {

    var _url = "http://localhost:40000/api/Muhasebe/Tum_Faturalari_Getir";
    $.ajax({
        url: _url,
        headers: {
            "authorization": "Bearer " + token,
        },
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (response) {
            console.log(response);

            setDxDataGrid(response);
        },
        failure: function (er) {
            console.log(er)
        }
    });
});

function setDxDataGrid(response) {
    $('#gridContainer').dxDataGrid({
        dataSource: {
            store: {
                type: 'array',
                data: response.Liste,
                key: 'ObjectId'
            }
        },
        showBorders: true,
        showRowLines: true,
        rowAlternationEnabled: true,
        allowColumnReordering: true,
        allowColumnResizing: true,
        columnAutoWidth: true,
        searchPanel: {
            width: 1230,
            visible: true,
        },
        paging: {
            pageSize: 20,
            enabled: true,
        },
        editing: {
            mode: 'row',
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
        },
        columnFixing: {
            enabled: true,
        },
        columns: [

            {

                dataField: 'ObjectId',
                alignment: 'center',
                caption: "Fatura No",
                allowEditing: false,
                fixed: true
            },
            {
                dataField: 'HizmetAdı',
                alignment: 'center',
                visible: false
            },
            {
                dataField: 'FaturaBedeli',
                alignment: 'center',
                width: 120,

            },
            {
                dataField: 'TahsilatId',
                caption: "Tahsilat No",
                alignment: 'center',

            },
            {
                dataField: 'Donem',
                caption: "Dönem",
                alignment: 'center',
            },
            {
                dataField: 'Kdv',
                alignment: 'center',
                allowEditing: false,
            },
            {
                dataField: 'KdvOncesiTutar',
                caption: "KDV Öncesi",
                alignment: 'center',
                allowEditing: false,
            },
            {
                dataField: 'AboneId',
                caption: "Abone Adı",
                alignment: 'center',
                calculateDisplayValue: function (data) {
                    var aboneList = Tum_Aboneleri_Listele();
                    var abone = aboneList.find(x => x.ObjectId == data.AboneId);
                    return abone.AdSoyad;
                }
            },
            {
                dataField: 'Odendi',
                caption: "Ödendi",
                alignment: 'center',
            },
            {
                dataField: 'KayıtTarih',
                dataType: "date",
                alignment: 'center',
                format: 'dd/MM/yyyy',
                allowEditing: false,
            },
            {
                dataField: 'DuzeltmeTarihi',
                dataType: "date",
                format: 'dd/MM/yyyy',
                allowEditing: false,
            },
            {
                dataField: 'SilmeTarihi',
                dataType: "date",
                alignment: 'center',
                format: 'dd/MM/yyyy',
                allowEditing: false,
            },
            {
                dataField: 'Aktif',
                alignment: 'center',

            },
        ],
        focusedRowEnabled: true,
        focusedRowKey: 1,


        onEditingStart() {
            console.log("onEditingStart");
        },
        onInitNewRow() {
            console.log("onInitNewRow");

        },
        onRowInserting(data) {
            console.log("onRowInserting");

            if (data.data.hasOwnProperty('__KEY__')) {
                delete data.data['__KEY__'];
            }
            var _url = "http://localhost:40000/api/Muhasebe/Donem_Faturasi_Ekle";
            $.ajax({
                url: _url,
                header: {
                    "authorization": "Bearer " + token,
                },
                data: JSON.stringify(data.data),
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                async: false,
                success: function (response) {
                    console.log("kayıt tamamlandı")
                },
                failure: function (er) {
                    console.log(er)
                }
            });
            console.log("onRowInserting");


            console.log(data.data);
        },
        onRowInserted() {
            console.log("onRowInserted");
        },
        onRowUpdating() {
            console.log("onRowUpdating");

        },
        onRowUpdated(data) {
            console.log("onRowUpdated");
            console.log(data);

            var _url = "http://localhost:40000/api/Muhasebe/Fatura_Guncelle";
            $.ajax({
                url: _url,
                headers: {
                    "authorization": "Bearer " + token,
                },
                data: JSON.stringify(data.key),
                type: 'PUT',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                async: false,
                success: function (response) {
                    console.log(response);
                    location.reload();
                },
                failure: function (er) {
                    console.log(er)
                }
            });
            console.log(data.key);

        },
        onRowRemoving(data) {

            console.log("onRowRemoving");

            if (data.data.hasOwnProperty('__KEY__')) {
                delete data.data['__KEY__'];
            }
            var _url = "http://localhost:40000/api/Muhasebe/Fatura_Sil";
            $.ajax({
                url: _url,
                headers: {
                    "authorization": "Bearer " + token,
                    "faturaId": data.data.ObjectId,
                },
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                async: false,
                success: function (response) {
                    console.log(response);
                    location.reload();
                },
                failure: function (er) {
                    console.log(er)
                }
            });
        },
        onRowRemoved() {
            console.log("onRowRemoved");
        },
        onSaving() {
            console.log("onSaving");
        },
        onSaved() {
            console.log("onSaved");
        },
        onEditCanceling() {
            console.log("onEditCanceling");
        },
        onEditCanceled() {
            console.log("onEditCanceled");
        },


    });
}

function Tum_Aboneleri_Listele() {
    var _url = "http://localhost:40000/api/Sistem/Tum_Aboneleri_Getir";
    var aboneList;
    $.ajax({
        url: _url,
        headers: {
            "authorization": "Bearer " + token,
        },
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (response) {
            console.log(response);

            aboneList = response.Liste;
        },
        failure: function (er) {
            console.log(er)
        }
    });
    return aboneList;
}