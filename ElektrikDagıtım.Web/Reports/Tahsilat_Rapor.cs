using System;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using ElektrikDagıtım.Entities.ViewModel.Muhasebe;
using Entities.Concrete.General;

namespace ElektrikDagıtım.Web.Reports
{
    public partial class Tahsilat_Rapor
    {
        public Tahsilat_Rapor(Mesajlar<V_TAHSILAT>  rapor)
        {
            InitializeComponent();
            Doldur(rapor);
        }
        public async void Doldur(Mesajlar<V_TAHSILAT> rapor)
        {
            List<double> tahsilatListesi = new();
            date.Text = DateTime.Now.ToShortDateString();


            foreach (var item in rapor.Liste)
            {
                try
                {
                    tahsilatListesi.Add(item.FaturaBedeli);


                    XRTableRow tblrow_tahsilat = new XRTableRow();
                    tblrow_tahsilat.HeightF = 35;

                    XRTableCell tblcell_faturaNo = new XRTableCell();
                    tblcell_faturaNo.WidthF = 121;
                    tblcell_faturaNo.Text = item.FaturaObjectID.ToString();
                    tblcell_faturaNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    tblcell_faturaNo.BackColor = System.Drawing.Color.Transparent;
                    tblrow_tahsilat.Cells.Add(tblcell_faturaNo);

                    XRTableCell tblcell_Aciklama = new XRTableCell();
                    tblcell_Aciklama.WidthF = 121;
                    tblcell_Aciklama.Text = item.Acıklama;
                    tblcell_Aciklama.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    tblcell_Aciklama.BackColor = System.Drawing.Color.Transparent;

                    tblrow_tahsilat.Cells.Add(tblcell_Aciklama);

                    XRTableCell tblcell_Donem = new XRTableCell();
                    tblcell_Donem.WidthF = 121;
                    tblcell_Donem.Text = item.Donem;
                    tblcell_Donem.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    tblcell_Donem.BackColor = System.Drawing.Color.Transparent;
                    tblrow_tahsilat.Cells.Add(tblcell_Donem);

                    XRTableCell tblcell_KdvOncesi = new XRTableCell();
                    tblcell_KdvOncesi.WidthF = 121;
                    tblcell_KdvOncesi.Text = item.FaturaKdvOncesiTutar.ToString() + "₺";
                    tblcell_KdvOncesi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    tblcell_KdvOncesi.BackColor = System.Drawing.Color.Transparent;
                    tblrow_tahsilat.Cells.Add(tblcell_KdvOncesi);

                    XRTableCell tblcell_Kdv = new XRTableCell();
                    tblcell_Kdv.WidthF = 121;
                    tblcell_Kdv.Text = "%20";
                    tblcell_Kdv.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    tblcell_Kdv.BackColor = System.Drawing.Color.Transparent;
                    tblrow_tahsilat.Cells.Add(tblcell_Kdv);

                    XRTableCell tblcell_Tutar = new XRTableCell();
                    tblcell_Tutar.WidthF = 121;
                    tblcell_Tutar.Text = item.FaturaBedeli.ToString() + "₺";
                    tblcell_Tutar.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    tblcell_Tutar.BackColor = System.Drawing.Color.Transparent;
                    tblrow_tahsilat.Cells.Add(tblcell_Tutar);

                    tblFatura.Rows.Add(tblrow_tahsilat);


                    label7.Text = item.AdSoyad;

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            label8.Text = tahsilatListesi.Sum().ToString() + "₺";
            label9.Text = tahsilatListesi.Sum().ToString() + "₺";



            XRTableRow tblrow_toplam = new XRTableRow();
            tblrow_toplam.HeightF = 25;

            XRTableCell tblcell_toplam = new XRTableCell();
            tblcell_toplam.WidthF = 605;
            tblcell_toplam.Text = "TOPLAM";
            tblcell_toplam.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            tblcell_toplam.BackColor = System.Drawing.Color.Transparent;
            tblrow_toplam.Cells.Add(tblcell_toplam);

            XRTableCell tblcell_toplamTutar = new XRTableCell();
            tblcell_toplamTutar.WidthF = 121;
            tblcell_toplamTutar.Text = tahsilatListesi.Sum().ToString() + "₺";
            tblcell_toplamTutar.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            tblcell_toplamTutar.BackColor = System.Drawing.Color.Transparent;
            tblrow_toplam.Cells.Add(tblcell_toplamTutar);

            tblFatura.Rows.Add(tblrow_toplam);


        }
    }
}
