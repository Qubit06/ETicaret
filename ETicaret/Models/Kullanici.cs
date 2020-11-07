using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ETicaret.Models
{
    public class Kullanici :EntityBase
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        [DisplayName("E-Posta")]
        public string Mail { get; set; }
        [DisplayName("Telefon Numarası")]
        public string TelefonNo { get; set; }
        [DisplayName("Şifre")]
        public string Sifre { get; set; }
        [DisplayName("Kimlik Numarası")]
        public string TC { get; set; }
        [DisplayName("Aktif mi ?")]
        public bool Aktif { get; set; }
        [DisplayName("Admin mi ?")]
        public bool Admin { get; set; }
        
    }
}