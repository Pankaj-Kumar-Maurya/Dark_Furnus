using System.ComponentModel.DataAnnotations;

namespace Dark_Furnus.Models
{
    public class tblcountry
    {
        [Key]
        public int CountryId { get; set; }


        public string CountryName { get; set; }
    }
}