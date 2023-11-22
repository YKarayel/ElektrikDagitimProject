
function Login() {
    var dt = {};
    dt["Eposta"] = $('#Eposta').val();
    dt["Sifre"] = $('#Sifre').val();
    var _url = "http://localhost:40000/api/sistem/Abone_Kontrol";
    console.log(dt);
    $.ajax({
        url: _url,
        data: JSON.stringify(dt),
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        async: false,
        success: function (result) {
            if (result != null && result.Nesne != null) {
                var nesne = result.Nesne;
                console.log(nesne);

                $('#txtLogin').val(JSON.stringify(nesne));
                $('#frmLogin').submit();
            }
            else {
                $("#txtUyariHataliGiris").removeClass("collapse");
            }
        },
        failure: function (er) {
            console.log("hata" + er);
        }
    })
}

$(document).ready(function () {
    $('#btngiris').click(function () {
        var sonuc = $('#frmGirisForm').valid();
        if (sonuc = true) {
            Login();
        }
        else {
            $("#txtUyariHataliGiris").removeClass("collapse")
        }
    });
});
document.addEventListener('keyup', (event) => {
    if (event.keyCode == 13) {
        console.log(event.key);
        var btn = $('#btngiris');
        btn.click();
    }
}, false);