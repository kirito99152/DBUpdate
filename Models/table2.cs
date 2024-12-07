using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBUpdate.Models
{
    [Table("dmHuyen", Schema = "DM")]
    public class table2
    {
        [Key]
        [Column("Id" + "Huyen")]
        public int Id1 { get; set; }
        [Column("TenHuyen")]
        public string b { get; set; }
        [Column("IdTinh")]
        public int? Id2 { get; set; }
        [ForeignKey("Id1")]
        public virtual table3? Table3 { get; set; }
        public virtual ICollection<table1>? Table1s { get; set; } = new List<table1>();
    }
}
