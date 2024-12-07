using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBUpdate.Models
{
    [Table("dm" + "TrangThaiHopDong", Schema = "DM")]
    public class Nhap
    {
        [Key]
        [Column("Id" + "TrangThaiHopDong")]
        public int Id { get; set; }
        [Column("TrangThaiHopDong")]
        public string a { get; set; }
    }
}
