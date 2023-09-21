using Dark_Furnus.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dark_Furnus.Controllers
{
    public class RegController : Controller
    {

        public readonly DatabaseContext db;

        public RegController(DatabaseContext database)
        {
            this.db = database;
        }
        [HttpGet]
        public IActionResult RegistrationForm()
        {
            TableCollection obj=new TableCollection();
            obj.CountryList=db.tblcountrys.ToList();
            obj.GenderList=db.tblgenders.ToList();
          //ViewBag.ctr=db.tblcountrys.ToList();
          //ViewBag.gdr=db.tblgenders.ToList();
            return View(obj);
        }
        [HttpPost]
        public IActionResult RegistrationForm(TableCollection TCobj)
        {
            tblRegistration obj=new tblRegistration();
            obj.UserName=TCobj.UserName;
            obj.Password=TCobj.Password;
            obj.Email=TCobj.Email;
            obj.GamingName=TCobj.GamingName;
            obj.Gender=TCobj.Gender;
            obj.Country=TCobj.Country;
            obj.FavoriteGame=TCobj.FavoriteGame;
            obj.State=TCobj.State;
            db.tblRegistrations.Add(obj);
            db.SaveChanges();
            
             return RedirectToAction("Show");

            
        }

        public IActionResult Show()
        {
            var data=(from a in db.tblRegistrations 
                      join b in db.tblcountrys on a.Country equals b.CountryId
                      join c in db.tblgenders on a.Gender equals c.GenderId
                      join d in db.tblstates on a.State equals d.sid
                      select new tblRegistrationForJoin{
                        Id=  a.Id,
                         UserName= a.UserName,
                         GamingName= a.GamingName,
                         FavoriteGame= a.FavoriteGame,
                         CountryForJoin= b.CountryName,
                         StateForJoin=d.sname,
                         GenderForJoin= c.GenderName,
                         Email= a.Email,
                         Password= a.Password }).ToList();
            return View(data);
        }

        public IActionResult GetStates(int countryId)
        {
           
            var states = (from a in db.tblstates where a.cid==countryId select a).ToList();
            
             return Json(states); // Return the states as JSON
        }

        public IActionResult Delete(int Id)
        {
            var data = db.tblRegistrations.Find(Id);
            if(data != null)
            db.tblRegistrations.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Show");
        }

    }
}

