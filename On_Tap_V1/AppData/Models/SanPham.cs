using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppData.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(4,MinimumLength =4)]
        public string MaSp { get; set; }
        [StringLength(15,ErrorMessage ="Ten dai 15 ky tu")]
        public string TenSp { get; set; }
        [Range(1000,30000000,ErrorMessage ="Gia chi tu 1k den 30m")]
        public int Gia { get; set; }
        public int SlTon { get; set; }
        [Required(ErrorMessage ="can dien thong tin")]
        public string NhaSx { get; set; }
        public string ThuongHieu { get; set; }
    }
}