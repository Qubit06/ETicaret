using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ETicaret.Models
{
    public class SepetUrunler:EntityBase
    {
        [DisplayName("Sepet  ID")]
        public int SepetID { get; set; }
        [DisplayName("Ürün  ID")]
        public int UrunID { get; set; }
        public Urun Urun { get; set; }
        [DisplayName("Adet")]
        public int Adet { get; set; }
    }
}