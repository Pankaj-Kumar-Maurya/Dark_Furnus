using System.ComponentModel.DataAnnotations;

namespace Dark_Furnus.Models
{
    public class tblgender
    {
        [Key]
        public int GenderId { get; set; }
        public string GenderName { get; set; }
    }
}