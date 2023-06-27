using _4OP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Security;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace _4OP.Controllers
{
    [ApiController]
    [Route("/Client")]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            MainDBContext db = new MainDBContext();
            List<Client> Clients = db.Clients.ToList();
            string jsonClients = JsonSerializer.Serialize(Clients);
            return Ok(jsonClients);
        }
        [HttpPost]
        public ActionResult Add(Client client)
        {
            MainDBContext db = new MainDBContext();
            if (db == null) return StatusCode(500);
            if (client.Id != 0)
                db.Clients.Update(client);
            else
                db.Clients.Add(client);
            db.SaveChanges();
            string jsonClient = JsonSerializer.Serialize(client);
            return Ok(jsonClient);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            MainDBContext db = new MainDBContext();
            if (db == null) return StatusCode(500);
            Client client = db.Clients.Find(id);
            if (client == null) return NotFound();
            db.Clients.Remove(client);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public ActionResult Replace(Client client)
        {
            Delete(client.Id);
            Add(client);
            return Ok();
        }
    }
}
