using _4OP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Security;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace _4OP.Controllers
{
    [ApiController]
    [Route("/Personal")]
    public class PersonalController:ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            MainDBContext db = new MainDBContext();
            List<Personal> Personals = db.Personals.ToList();
            string jsonPersonals = JsonSerializer.Serialize(Personals);
            return Ok(jsonPersonals);
        }
        [HttpPost]
        public ActionResult Add(Personal personal)
        {
            MainDBContext db = new MainDBContext();
            if (db == null) return StatusCode(500);
            if(personal.Id !=0)
                    db.Personals.Update(personal);
            else
            db.Personals.Add(personal);
            db.SaveChanges();
            string jsonPersonal = JsonSerializer.Serialize(personal);
            return Ok(jsonPersonal);
        }
        [HttpDelete]
        public ActionResult Delete(int id) { 
            MainDBContext db = new MainDBContext();
            if (db == null) return StatusCode(500);
            Personal personal = db.Personals.Find(id);
            if (personal == null) return NotFound();
            db.Personals.Remove(personal);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public ActionResult Replace(Personal personal)
        {
            Delete(personal.Id);
            Add(personal);
            return Ok();
        }
    }
}
