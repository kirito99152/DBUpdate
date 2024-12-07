using System.ComponentModel.DataAnnotations;

namespace DBUpdate.Models
{
    public class data
    {
        [Key]
        public int object_id { get; set; }
        public string name { get; set; }
    }
}
