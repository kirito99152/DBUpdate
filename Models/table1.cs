using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBUpdate.Models
{
    [Table("dm" + "Xa", Schema = "DM")]
    public class table1
    {
        [Key]
        [Column("Id" + "Xa")]
        public int Id { get; set; }
        [Column("TenXa")]
        public string a { get; set; }

        [Column("IdHuyen")]
        public int? Id1 { get; set; }        
        
        [ForeignKey("Id1")]
        public virtual table2? Table2 { get; set; }
    }
}
