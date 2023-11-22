/*odenmisFaturalar = [];*/
$(document).ready(function () {
    Tahsilatlari_Getir();
    function Tahsilatlari_Getir() {

        var _url = "http://localhost:40000/api/Muhasebe/Abone_Tahsilatlarini_Getir";

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

                        var tarih = new Date(liste[i].KayıtTarih).toLocaleDateString();

                        var tbody = $("#ftrbody");
                        var data = ` 
                                <tr class="border">
                                      <th scope="row"><input class="form-check-input" type="checkbox">
                                        <td class="text-center">${liste[i].ObjectId}</td>
                                        <td>${tarih}</td>
                                        <td class="text-center">Eklenecek</td>
                                        <td>${userName}</td>
                                        <td>Elektrik Fatura Ödemesi</td>
                                        <td class="text-center">${liste[i].KdvOncesiTutar}₺</td>
                                        <td>%20</td>
                                        <td class="text-center"><span class="fw-bolder">${liste[i].TahsilatTutari}₺</span></td>
                                        <td><a type="button" class="btn-outline-success" name="thsltgrntle" target="_blank" value="${liste[i].ObjectId}"><i class="fa-solid fa-file-invoice fa-xl"></i></a></td>



                                        <td class="d-none">${liste[i].AboneId}</td>
                                     </th>
                                 </tr>`;

                        tbody.append(data);
                    }
                }
            }
        })

        $('a[name="thsltgrntle"]').on('click', function (event) {
            event.preventDefault();

            var tahsilatId = $(this).attr('value');
            window.open('https://localhost:44306/rapor/Tahsilat_Raporu_Getir?ObjectId=' + tahsilatId, '_blank');

        });

    }
});