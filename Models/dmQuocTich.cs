using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DBUpdate.Models
{
    //[Table("dm" + "KhoiNganhLinhVucDaoTao", Schema = "DM")]
    public class dmQuocTich
    {
        public int Id { get; set; }
        public int Id1 { get; set; }
        public int Id2 { get; set; }
        public string a { get; set; }
        public string b { get; set; }
        public string c { get; set; }
    }
}
