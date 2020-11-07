using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETicaret.Models
{
    public class Siparis:EntityBase
    {
        public int KullaniciID { get; set; }
        public Kullanici Kullanici { get; set; }
        public int UrunID { get; set; }
        public Urun Urun { get; set; }
        public int SepetID { get; set; }
        public decimal ToplamUrunFiyat { get; set; }
        public decimal? ToplamKDVFiyat { get; set; }
        public decimal? TotalIndirimFiyat { get; set; }
        public decimal ToplamFiyat { get; set; }
    }
}