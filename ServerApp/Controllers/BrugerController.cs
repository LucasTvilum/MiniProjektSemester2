using Microsoft.AspNetCore.Mvc;
using ServerApp.Repository;
using Core.Models;


namespace ServerApp.Controllers
{
    [ApiController]
    [Route("api/bruger")]
    public class BrugerController : ControllerBase
    {

       
        private IBrugerRepository brugerRepo;

        public BrugerController(IBrugerRepository brugerRepo) {
            this.brugerRepo = brugerRepo;
        }

        [HttpGet]
        public IEnumerable<Bruger> Get()
        {
            return brugerRepo.GetAll();
        }
        
        [HttpPost]
        public void Add(Bruger bruger) {
            brugerRepo.Add(bruger);
        }


        [HttpGet("{id}")]
        public ActionResult<Bruger> Update(string id, [FromBody] Bruger bruger)
        {
            bruger.Id = id;
            var updated =  brugerRepo.Update(bruger);
            if ((updated = null) != null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete]
        [Route("delete")]
        public void DeleteByQuery([FromQuery] string id)
        {
            brugerRepo.Delete(id);
        }
        
    }
}