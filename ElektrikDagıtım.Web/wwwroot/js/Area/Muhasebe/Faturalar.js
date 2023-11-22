
var faturalar = [];



$(document).ready(function () {


    AboneFaturalariniGoster();
    Fatura_Goruntule();
    document.querySelectorAll('button[name="odemeyap"]').forEach(function (button) {
        button.addEventListener('click', OdemeYap())
    });

    function AboneFaturalariniGoster() {
        var _url = "http://localhost:40000/api/Muhasebe/Abone_Tum_Faturalari_Getir";

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

                        var date = new Date(liste[i].KayıtTarih).toLocaleDateString();

                        if (liste[i].Odendi == true) {
                            var check = `<i class="fa fa-check-circle"></i>`
                        }
                        else {
                            var check = `<i class="fa fa-check-circle-o"></i>`
                        }

                        var tbody = $("#ftrbody");
                        var data = `
                             <tr class="border">
                                  <th scope="row"><input class="form-check-input" type="checkbox">
                                  <td class="text-center">${liste[i].ObjectId}</td>
                                  <td>${date}</td>
                                  <td class="text-center">${liste[i].Donem}</td>
                                  <td>${userName}</td>
                                  <td>${liste[i].HizmetAdı}</td>
                                  <td class="text-center">${liste[i].KdvOncesiTutar}₺</td>
                                  <td>%20</td>
                                  <td class="text-center"><span class="fw-bolder">${liste[i].FaturaBedeli}₺</span></td>
                                  <td class="text-center">${liste[i].TahsilatId}</td>
                                  <td><button type="button" class="btn btn-outline-success text-center" name="odemeyap" data-bs-toggle="modal" data-bs-target="#odemeModal">Ödeme Yap</button></td>
                                  <td><a type="button" class="btn-outline-success" name="ftrgrntle" target="_blank" value="${liste[i].ObjectId}"><i class="fa-solid fa-file-invoice fa-xl"></i></a></td>
                                  <td class="d-none">${liste[i].AboneId}</td> 
                                 </th>
                             </tr>`;

                        tbody.append(data);
                    }
                }
                else {
                    $("#").removeClass("collapse");
                }
            },
            failure: function (er) {
                console.log("hata" + er);
            }
        })
    }

    function Fatura_Goruntule() {

        //var _url = "http://localhost:40000/api/Muhasebe/V_Fatura_Getir";
        //var sonuc;
        //$.ajax({
        //    async: false,
        //    url: _url,
        //    type: 'GET',
        //    async: false,
        //    headers: {
        //        "accept": "application/json",
        //        "content-type": "application/json",
        //        "authorization": "Bearer " + token,
        //        "faturaId" : 4

        //    },
        //    contentType: 'application/json; charset=utf-8',
        //    dataType: 'json',
        //    success: function (result) {

        //        sonuc = result;
        //    },
        //    failure: function (er) {
        //        console.log("Dönen Hata");
        //        console.log(er);
        //    },
        //    complete: function () {

        //    }
        //});
        
        //console.log(sonuc);
        

        //var Nesne = {};

        //Nesne["ObjectId"] = sonuc.Nesne.ObjectId;
        //Nesne["AdSoyad"] = sonuc.Nesne.AdSoyad;
        //Nesne["Eposta"] = sonuc.Nesne.Eposta;
        //Nesne["GsmNo"] = sonuc.Nesne.GsmNo;
        //Nesne["TC"] = sonuc.Nesne.TC;
        //Nesne["HizmetAdı"] = sonuc.Nesne.HizmetAdı;
        //Nesne["FaturaBedeli"] = sonuc.Nesne.FaturaBedeli;
        //Nesne["Kdv"] = sonuc.Nesne.Kdv;
        //Nesne["AboneId"] = sonuc.Nesne.AboneId;
        //Nesne["Odendi"] = sonuc.Nesne.Odendi;
        //Nesne["TahsilatId"] = sonuc.Nesne.TahsilatId;
        //Nesne["Aktif"] = sonuc.Nesne.Aktif;
        //Nesne["DuzeltmeTarihi"] = sonuc.Nesne.DuzeltmeTarihi;
        //Nesne["KayıtTarih"] = sonuc.Nesne.KayıtTarih;
        //Nesne["SilmeTarihi"] = sonuc.Nesne.SilmeTarihi;
        //Nesne["KdvOncesiTutar"] = sonuc.Nesne.KdvOncesiTutar;
        //Nesne["Donem"] = sonuc.Nesne.Donem;

        //var vFatura = JSON.stringify(sonuc.Nesne);
        //$.ajax({

        //    url: "/rapor/fatura_raporu",
        //    data: vFatura,
        //    headers: {
        //        "accept": "application/json",
        //        "content-type": "application/json"
        //    },
        //    type: 'POST',
        //    contentType: 'application/json; charset=utf-8',
        //    dataType: 'json',
        //    async: false,
        //    success: function (result) {

        //        if (result != null) {

        //            sonuc = result;
        //        }


        //    },
        //    failure: function (er) {
        //        console.log("Dönen Hata");
        //        console.log(er);
        //    }
        //});


        $('a[name="ftrgrntle"]').on('click', function (event) {
            event.preventDefault();

            var faturaId = $(this).attr('value');
            window.open('https://localhost:44306/rapor/fatura_raporu_getir?ObjectId=' + faturaId, '_blank');

            //var Nesne = {};

            //Nesne["ObjectID"] = faturaId;
            //var vFatura = JSON.stringify(Nesne);
            //$.ajax({
            //    url: "/Rapor/Fatura_Raporu_Getir",
            //    type: 'POST',
            //    data: vFatura,
            //    headers: {
            //        "authorization": "Bearer " + token,
            //    },
            //    contentType: 'application/json; charset=utf-8',
            //    dataType: 'json',
            //    async: false,
            //    success: function (result) {
            //        console.log(result)
            //    },
            //    failure: function (result) {
            //        console.log(result);
            //    }
            //});
        });
    };
    function OdemeYap() {
        var selected = [];
        document.querySelectorAll('input[type="checkbox"]:checked').forEach(function (checkbox) {
            selected.push(checkbox.parentNode.nextElementSibling.textContent);
        });
        var toplam = 0;
        var ulfaturalar = $("#ulfatura");
        ulfaturalar.text(" ");
        faturalar = [];

        for (var i = 0; i < selected.length; i++) {

            faturalar.push(liste.find(x => x.ObjectId == selected[i]));
            toplam += faturalar[i].FaturaBedeli;

            var data = `<li id="liftr" class="list-group-item d-flex justify-content-between align-items-center border-0 px-0 pb-0" >
                            Fatura No: ${faturalar[i].ObjectId}
                            <span>${faturalar[i].FaturaBedeli}₺</span>
                        </li>`
            ulfaturalar.append(data);
        }

        var ftrtoplam = `<hr>
                         <li class="list-group-item d-flex justify-content-between align-items-center border-0 px-0 pb-0">
                             <div>
                                 <strong>Total amount</strong>
                                  <p class="mb-0"><strong>(KDV DAHİL)</strong></p>
                             </div>
                             <span id="toplam"><strong>${toplam.toFixed(2)}</strong></span>
                         </li>`;
        ulfaturalar.append(ftrtoplam);
    };
});
function OdemeDevam() {
        if (faturalar.length > 0) {

            $.ajax({
                url: "http://localhost:40000/api/Muhasebe/Fatura_Ode",
                type: 'POST',
                headers: {
                    "authorization": "Bearer " + token,
                    "aboneId": userId
                },
                data: JSON.stringify(faturalar),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                async: false,
                success: function (result) {
                    location.reload();  //sayfayı yenileyerek ödemeden sonraki güncellenmiş datayı göster
                },
                failure: function (result) {
                    console.log(result);
                }
            });
        };
    }