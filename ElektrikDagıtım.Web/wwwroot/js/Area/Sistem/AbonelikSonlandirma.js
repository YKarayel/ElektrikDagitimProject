
$(document).ready(function () {

    AboneFaturalariGetir();


});

function AboneFaturalariGetir() {
    var _url = "http://localhost:40000/api/Muhasebe/Abone_Tum_Faturalari_Getir";
    var odmdurum = $("#odmdurum");
    $.ajax({
        url: _url,
        type: 'GET',
        headers: {
            "authorization": "Bearer " + token,
            "aboneId": userId
        },
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (result) {
            if (result != null && result.Liste != null) {
                liste = result.Liste;
                for (var i = 0; i < liste.length; i++) {
                    if (liste[i].Odendi == false) {
                        odmdurum.empty();
                        var odmdurumalert = `<div class="alert alert-danger" role="alert">
                                                Ödenmemiş faturanız bulunmaktadır. Lütfen faturalar sayfasına giderek ödeme yapınız. Ödemelerin ardından bu sayfadan aboneliğinizi iptal edebilirsiniz ardından 7 iş günü içerisinde depozito bedeliniz hesabınıza yatırılacaktır.
                                            </div>`
                        var btnfatura = `<br><a type="button" class="btn btn-primary" href="/Muhasebe/Muhasebe/Faturalar">Faturalar</a>`
                    }
                    odmdurum.append(odmdurumalert);
                    odmdurum.append(btnfatura);
                }
            }
        }
    });
};