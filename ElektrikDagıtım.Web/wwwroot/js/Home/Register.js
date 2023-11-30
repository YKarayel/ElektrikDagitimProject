
$(document).ready(function () {
    $('#odemedvm').click(function () {
        YeniAboneKayit();
    });
});

function YeniAboneKayit() {

    var kontrol = $("#formabone").valid()
    if (kontrol) {
        var abone = {
            AdSoyad: $("#AdSoyad").val(),
            Eposta: $("#Eposta").val(),
            Sifre: $("#Sifre").val(),
            GsmNo: $("#GsmNo").val(),
            TC: $("#TC").val(),
        };

        var _url = "http://localhost:40000/api/sistem/Yeni_Abone";
        $.ajax({
            url: _url,
            data: JSON.stringify(abone),
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            async: false,
            success: function (response) {
                console.log(response);
                $('#kayıtbasarili').modal("show");

            },
            failure: function (er) {
                var data = `<div class="alert alert-danger" role="alert">Hata oluştu lütfen kaydınızı tekrar yapınız</div>`

            }
        });
    }
    else {
        console.log("hatalı kayıt");
    }
}

function AboneKontrol() {
    var kontrol = $("#formabone").valid()
    if (kontrol) {
        var abone = {
            AdSoyad: $("#AdSoyad").val(),
            Eposta: $("#Eposta").val(),
            Sifre: $("#Sifre").val(),
            GsmNo: $("#GsmNo").val(),
            TC: $("#TC").val(),
        };
        $("#exampleModal").modal("show");
        
    }
}

