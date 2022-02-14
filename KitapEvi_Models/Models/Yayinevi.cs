using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapEvi_Models.Models
{
    [Table("tb_Yayinevi")]
    public class Yayinevi
    {
        public int YayinEviID { get; set; }
        [Required]
        public string YayinEviAdi { get; set; }
        public string Lokasyon { get; set; }

        public List<Kitap> Kitap { get; set; }

    }
}
