using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapEvi_Models.Models
{
    [Table("tb_Tur")]
    public class Tur
    {
        public int TurID { get; set; }
        public string TurAd { get; set; }
    }
}
