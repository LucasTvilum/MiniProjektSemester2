using Microsoft.AspNetCore.Mvc;
using ServerApp.Repository;
using Core.Models;


namespace ServerApp.Controllers
{
    [ApiController]
    [Route("api/annonce")]
    public class AnnonceController : ControllerBase
    {

       
        private IAnnonceRepository annonceRepo;

        public AnnonceController(IAnnonceRepository annonceRepo) {
            this.annonceRepo = annonceRepo;
        }

        [HttpGet]
        public IEnumerable<Annonce> Get()
        {
            return annonceRepo.GetAll();
        }
        
        [HttpPost]
        public void Add([FromBody]Annonce annonce) {
            Console.WriteLine("Add annonceservice");
            annonceRepo.Add(annonce);
        }
        
        
        [HttpGet("{id}")]
        public ActionResult<Annonce> GetById(string id)
        {
            var annonce = annonceRepo.GetAll().FirstOrDefault(a => a.Id == id);
            if (annonce == null) return NotFound();
            return Ok(annonce);
        }

        [HttpDelete]
        [Route("delete")]
        public void DeleteByQuery([FromQuery] string id)
        {
            annonceRepo.Delete(id);
        }
        
        
    }
}