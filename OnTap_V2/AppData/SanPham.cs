using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        [StringLength(4,MinimumLength =4,ErrorMessage ="Do dai chi dc 4 ky tu")]
        public string MaSP { get; set; }
        [StringLength(15,ErrorMessage ="Ko duoc dai qua 15 ky tu")]
        public string TenSP { get; set; }
        [Range(1000,30000000,ErrorMessage ="Gia tu 1k den 30m")]
        public int Gia { get; set; }
        public int SLTon { get; set; }
        [Required(ErrorMessage ="Phai nhap")]
        public string NSX { get; set; }
        public string ThuongHieu { get; set; }
    }
}
