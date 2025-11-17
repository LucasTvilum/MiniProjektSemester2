using Microsoft.AspNetCore.Mvc;
using ServerApp.Repository;
using Core.Models;


namespace ServerApp.Controllers
{
    [ApiController]
    [Route("api/annonce")]
    public class LokaleController : ControllerBase
    {

       
        private ILokaleRepository lokaleRepo;

        public LokaleController(ILokaleRepository lokaleRepo) {
            this.lokaleRepo = lokaleRepo;
        }

        [HttpGet]
        public IEnumerable<Lokale> Get()
        {
            return lokaleRepo.GetAll();
        }
        
        [HttpPost]
        public void Add(Lokale lokale) {
            lokaleRepo.Add(lokale);
        }


        [HttpGet("{id}")]
        public ActionResult<Lokale> Update(string id, [FromBody] Lokale lokale)
        {
            lokale.Id = id;
            var updated =  lokaleRepo.Update(lokale);
            if ((updated = null) != null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete]
        [Route("delete")]
        public void DeleteByQuery([FromQuery] string id)
        {
            lokaleRepo.Delete(id);
        }
        
    }
}