using System.ComponentModel.DataAnnotations;

namespace Dark_Furnus.Models
{
    public class tblstate
    {
        [Key]
        public int sid { get; set; }
        public int cid { get; set; }
        public string sname { get; set; }
    }
}
