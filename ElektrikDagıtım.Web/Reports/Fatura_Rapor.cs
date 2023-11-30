using System;
using System.Net.Http.Headers;
using DevExpress.DataAccess.Native.Web;
using DevExpress.XtraReports.UI;
using ElektrikDagitim.Entities.Concrete.General;
using ElektrikDagitim.Entities.Concrete.Muhasebe;
using ElektrikDagitim.Entities.Concrete.Sistem;
using ElektrikDagitim.Entities.ViewModel.Muhasebe;
using Newtonsoft.Json;

namespace ElektrikDagitim.Web.Reports
{
    public partial class Fatura_Rapor
    {
        public Fatura_Rapor(Mesajlar<V_FATURA> rapor)
        {
            InitializeComponent();
            Doldur(rapor);
        }
        public async void Doldur(Mesajlar<V_FATURA> rapor)
        {
            customerName.Text = rapor.Nesne.AdSoyad;
            invoiceDate.Text = DateTime.Now.ToShortDateString();
            invoiceNumber.Text = rapor.Nesne.ObjectId.ToString();
            productName.Text = rapor.Nesne.HizmetAdı + " " + rapor.Nesne.Donem;
            unitPrice.Text = rapor.Nesne.KdvOncesiTutar.ToString();
            unitTax.Text = "%20";
            lineTotal.Text = rapor.Nesne.FaturaBedeli.ToString();
            subtotal.Text = rapor.Nesne.FaturaBedeli.ToString();
            tax.Text = "%20";
            total.Text = rapor.Nesne.KdvOncesiTutar.ToString();


        }
    }
}
