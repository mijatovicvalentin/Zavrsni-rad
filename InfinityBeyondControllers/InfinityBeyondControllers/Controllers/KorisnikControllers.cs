using InfinityBeyondControllers;
using InfinityBeyondControllers.Data;
using InfinityBeyondControllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfinityBeyondControllers.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KorisnikController : ControllerBase
    {

        private readonly InfinityBeyondContext _context;

        public KorisnikController(InfinityBeyondContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return new JsonResult(_context.korisnikss.ToList());
        }

        [HttpPost]
        public IActionResult Post(Korisnik korisnik)
        {
            _context.korisnikss.Add(korisnik);
            _context.SaveChanges();
         
            return Created("/api/v1/Smjer", korisnik); 
        }


        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Korisnik korisnik)
        {
            



            return StatusCode(StatusCodes.Status200OK, korisnik);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            return StatusCode(StatusCodes.Status200OK, "{\"obrisano\":true}");
        }
    }
}