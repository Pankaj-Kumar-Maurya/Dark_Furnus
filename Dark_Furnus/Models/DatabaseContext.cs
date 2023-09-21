using Microsoft.EntityFrameworkCore;

namespace Dark_Furnus.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<tblRegistration> tblRegistrations { get; set; }
        public DbSet<tblcountry> tblcountrys { get; set; }
        public DbSet<tblgender> tblgenders { get; set; }
        public DbSet<tblstate> tblstates { get; set; }


    }
}
