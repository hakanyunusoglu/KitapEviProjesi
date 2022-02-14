using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace KitapEvi_Models.Models
{
    [Table("tb_Kategori")]
    public class Kategori
    {   //Table DataAnnotations : Veritabanında tablo adını düzenlemek için kullanılır.
        //Column DataAnnotations: Veritabanında yer alan tablo içindeki kolon adını değiştirmek için kullanılır.
        public int KategoriID { get; set; }
        [Column("Ad")]
        [Required(ErrorMessage ="Bu alan boş geçilemez!")]
        public string KategoriAdi { get; set; }
    }
}