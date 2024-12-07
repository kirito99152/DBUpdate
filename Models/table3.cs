using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBUpdate.Models
{
    [Table("dmTinh", Schema = "DM")]
    public class table3
    {
        [Key]
        [Column("IdTinh")]
        public int Id2 { get; set; }
        [Column("TenTinh")]
        public string c { get; set; }
        public virtual ICollection<table2>? Table2s { get; set; } = new List<table2>();
    }
}
