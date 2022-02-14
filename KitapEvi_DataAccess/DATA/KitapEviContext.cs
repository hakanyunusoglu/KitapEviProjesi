using KitapEvi_Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapEvi_DataAccess.DATA
{
    public class KitapEviContext:DbContext
    {
        public KitapEviContext(DbContextOptions<KitapEviContext> options):base(options)
        {

        }
        public DbSet<Tur> Turler { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Yayinevi> Yayinevleri { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<KitapYazarlar> KitapYazarlar { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent api ile configurasyon işlemi yapmak gerek Composite key oluşturmak için
            modelBuilder.Entity<KitapYazarlar>().HasKey(x=> new {x.YazarID, x.KitapID});
        }
        public DbSet<KitapDetay> KitapDetaylar { get; set; }


    }
}
