using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ETicaret.Models
{
    public class Kategori:EntityBase
    {
        //public int EbeveynID { get; set; } = 0;
        [DisplayName("Kategori Ad")]
        public string KategoriAd { get; set; }
        [DisplayName("Aktif mi?")]
        public bool Aktif { get; set; }
      

    }
}