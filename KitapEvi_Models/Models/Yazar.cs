using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapEvi_Models.Models
{
    [Table("tb_Yazar")]
    public class Yazar
    {
        public int YazarID { get; set; }
        [Required]
        public string YazarAdi { get; set; }
        [Required]
        public string YazarSoyadi { get; set; }
        [Required]
        public string YazarLokasyon { get; set; }
        public DateTime YazarDogumTarihi { get; set; }
        [NotMapped]
        public string AdSoyad { get {return $"{YazarAdi} {YazarSoyadi}";}}

    } 
}
