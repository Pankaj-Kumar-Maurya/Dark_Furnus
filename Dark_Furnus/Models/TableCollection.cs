namespace Dark_Furnus.Models
{
    public class TableCollection:tblRegistration
    {
        public List<tblcountry> CountryList { get; set; }
        public List<tblstate> StateList { get; set; }
        public List<tblgender> GenderList { get; set; } 
    }
}
