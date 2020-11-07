using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ETicaret.Models
{
    public class Urun:EntityBase
    {
        [DisplayName("Ürün Ad")]
        public string Ad { get; set; }
        [DisplayName("Kategori ID")]
        public int KategoriID { get; set; }
        public Kategori Kategori { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        [DisplayName("Resim")]
        public string ResimUrl { get; set; }
        [DisplayName("Açıklama")]
        public string Aciklama { get; set; }
        [DisplayName("Birim Fiyat")]
        public decimal BirimFiyat { get; set; }
        public decimal? KDV { get; set; }
        [DisplayName("İndirim")]
        public decimal? Indirim { get; set; }
        [DisplayName("Stok Adet")]
        public int StokAdet { get; set; }
        [DisplayName("Aktif mi")]
        public bool Aktif { get; set; }

    }
}