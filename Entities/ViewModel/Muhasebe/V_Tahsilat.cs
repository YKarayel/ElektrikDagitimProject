﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektrikDagitim.Entities.ViewModel.Muhasebe
{
    public class V_TAHSILAT
    {
        [Key]
        public long ObjectId { get; set; }

        public int TahsilatID { get; set; }
        public int AboneId { get; set; }
        public decimal KdvOncesiTutar { get; set; }
        public decimal KdvOranı { get; set; }
        public string Acıklama { get; set; }
        public decimal TahsilatTutari { get; set; }
        public bool Aktif { get; set; }
        public DateTime? DuzeltmeTarihi { get; set; }
        public DateTime? KayıtTarih { get; set; }
        public DateTime? SilmeTarihi { get; set; }

        public int FaturaObjectID { get; set; }
        public decimal FaturaBedeli { get; set; }

        public decimal FaturaKDV { get; set; }
        public decimal FaturaKdvOncesiTutar { get; set; }
        public string Donem { get; set; }
        public bool FaturaAktif { get; set; }
        public string AdSoyad { get; set; }
        public string Eposta { get; set; }
        public string GsmNo { get; set; }
        public string TC { get; set; }
        public bool AboneAktif { get; set; }





    }
}