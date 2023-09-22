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
        //[HttpGet]
        public IActionResult RegistrationForm(int id)
        {
            ViewBag.btn = "Register";
            TableCollection obj = new TableCollection();
            if (id > 0)
            {
                var data = db.tblRegistrations.Where(x => x.Id == id).ToList();
                obj.Id = data[0].Id;
                obj.UserName = data[0].UserName;
                obj.Password = data[0].Password;
                obj.Email = data[0].Email;
                obj.GamingName = data[0].GamingName;
                obj.FavoriteGame = data[0].FavoriteGame;
                obj.Country = data[0].Country;
                obj.State = data[0].State;
                obj.Gender = data[0].Gender;
                ViewBag.btn = "Update";
            }
            obj.CountryList = db.tblcountrys.ToList();
            obj.GenderList = db.tblgenders.ToList();
            obj.StateList = db.tblstates.Where(x => x.cid == obj.Country).ToList();
            //ViewBag.ctr=db.tblcountrys.ToList();
            //ViewBag.gdr=db.tblgenders.ToList();
            return View(obj);
        }
        [HttpPost]
        public IActionResult RegistrationForm(TableCollection TCobj)
        {
            tblRegistration obj = new tblRegistration();
            obj.UserName = TCobj.UserName;
            obj.Password = TCobj.Password;
            obj.Email = TCobj.Email;
            obj.GamingName = TCobj.GamingName;
            obj.Gender = TCobj.Gender;
            obj.Country = TCobj.Country;
            obj.FavoriteGame = TCobj.FavoriteGame;
            obj.State = TCobj.State;

            if (TCobj.Id > 0)
            {
                obj.Id = TCobj.Id;
                db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {

                db.tblRegistrations.Add(obj);
            }


            db.SaveChanges();

            return RedirectToAction("Show");


        }

        public IActionResult Show()
        {
            var data = (from a in db.tblRegistrations
                        join b in db.tblcountrys on a.Country equals b.CountryId
                        join c in db.tblgenders on a.Gender equals c.GenderId
                        join d in db.tblstates on a.State equals d.sid
                        select new tblRegistrationForJoin
                        {
                            Id = a.Id,
                            UserName = a.UserName,
                            GamingName = a.GamingName,
                            FavoriteGame = a.FavoriteGame,
                            CountryForJoin = b.CountryName,
                            StateForJoin = d.sname,
                            GenderForJoin = c.GenderName,
                            Email = a.Email,
                            Password = a.Password
                        }).ToList();
            return View(data);
        }

        public IActionResult GetStates(int countryId)
        {

            var states = (from a in db.tblstates where a.cid == countryId select a).ToList();

            return Json(states); // Return the states as JSON
        }

        public IActionResult Delete(int Id)
        {
            var data = db.tblRegistrations.Find(Id);
            if (data != null)
                db.tblRegistrations.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Show");
        }



    }
}

