using System.ComponentModel.DataAnnotations.Schema;

namespace DBUpdate.Models
{
    public class Tinh
    {
        [Column("IdTinh")]
        public int Id { get; set; }
        public string tEN { get; set; }
    }
}
