using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ETicaret.Models
{
    public class SiparisUrun:EntityBase
    {
        [DisplayName("Sipariş ID")]
        public int SiparisID { get; set; }
        [DisplayName("Ürün ID")]
        public int UrunID  { get; set; }
        public Urun Urun { get; set; }
        [DisplayName("Ürün Adet")]
        public int UrunAdet { get; set; }
    }
}