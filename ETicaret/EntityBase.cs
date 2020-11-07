using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETicaret
{
    public class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [DisplayName("Kayıt Oluşturulma Tarihi")]
        public DateTime OlusturulmaTarih { get; set; }
        [DisplayName("Kayıt Oluşturan Kullanıcı ID")]
        public int OlusturanKullaniciID { get; set; }
        [DisplayName("Kayıt Güncelleme Tarihi")]
        public DateTime? GuncellemeTarih { get; set; }
        [DisplayName("Kayıt Güncelleyen Kullanıcı ID")]
        public int? GuncellemeKullaniciID { get; set; }
        
    }
}