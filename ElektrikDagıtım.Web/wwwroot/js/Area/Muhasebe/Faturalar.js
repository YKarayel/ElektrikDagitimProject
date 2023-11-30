﻿
var faturalar = [];



$(document).ready(function () {


    AboneFaturalariniGoster();
    Fatura_Goruntule();

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
                                  <td class="text-center">${date}</td>
                                  <td class="text-center">${liste[i].Donem}</td>
                                  <td class="text-center">${userName}</td>
                                  <td class="text-center">${liste[i].HizmetAdı}</td>
                                  <td class="text-center">${liste[i].KdvOncesiTutar}₺</td>
                                  <td class="text-center">%20</td>
                                  <td class="text-center"><span class="fw-bolder">${liste[i].FaturaBedeli}₺</span></td>
                                  <td class="text-center">${liste[i].TahsilatId}</td>
                                  <td class="text-center"><a type="button" class="btn-outline-success" name="ftrgrntle" target="_blank" value="${liste[i].ObjectId}"><i class="fa-solid fa-file-invoice fa-xl "></i></a></td>
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

        


        $('a[name="ftrgrntle"]').on('click', function (event) {
            event.preventDefault();

            var faturaId = $(this).attr('value');
            window.open('https://localhost:44306/rapor/fatura_raporu_getir?ObjectId=' + faturaId, '_blank');
        });
    };
   
});

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