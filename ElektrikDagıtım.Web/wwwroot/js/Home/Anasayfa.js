var dataAnasayfa = [];
$(document).ready(function () {
  

    if (gecmodel != null) {
        dataModuller = gecmodel.Liste
    }
    Modul_Doldur(dataModuller);

    $('#txtAra').on('keyup', function (e) {

        $('#dvModul').empty();

        var dgr = $(this).val();

        var _data;

        if (dgr != null) {
            _data = dataModuller.filter(x => x.modulAd.toLowerCase().includes(dgr) == true);
        } else {
            _data = dataModuller;
        }

        Modul_Doldur(_data);

    });

});
function Modul_Doldur(data) {

    var ind = 0;

    for (var i = 0; i < data.length; i++) {


        var id = '#dvModul';

        var elm = "<div class=\"col-xl-4 col-sm-6 col-12 \" >" +
            " <div class=\"card dvCard\" onclick=\"window.location = \'" + data[i].modulUrl + "\'\"> " +
            " <div class=\"card-content\"> " +
            " <div class=\"card-body\"> " +
            " <div class=\"media d-flex\"> " +
            " <div class=\"align-self-center\"> " +
            " <i class=\"" + data[i].modulIcon + " fa-2x float-left\"></i> &emsp;" +
            " </div> " +
            " <div class=\"media-body text-right pt-1\"> " +
            "<h5>" + data[i].modulAd + "</h5> " +
            " <span></span> </div> </div> </div> </div> </div> </div>";


        $(id).append(elm);

        ind++;

        if (ind == 3) ind = 0;

    }

};