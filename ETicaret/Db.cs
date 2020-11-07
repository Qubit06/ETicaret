using ETicaret.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ETicaret
{
    public class Db :DbContext
    {
       
        public Db()
            : base(@"Data Source=DESKTOP-LOFIDJD;Initial Catalog=ETicaratDB;Integrated Security=True")
        {
          
        }
        public DbSet<Kullanici> Kullanicis { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }

        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Sepet> Sepets { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        public DbSet<SiparisUrun> SiparisUruns { get; set; }
        public DbSet<SepetUrunler> SepetUrunler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}