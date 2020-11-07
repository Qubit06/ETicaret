
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaret.Models
{
    
    public class Sepet : EntityBase
    {
        [DisplayName("Kullanıcı ID")]
        public int KullaniciID { get; set; }
        public int UrunID { get; set; }
        [DisplayName("Durum")]
        public int Durum { get; set; }
    }
}