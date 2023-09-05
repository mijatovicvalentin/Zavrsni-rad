using InfinityBeyondControllers1.Data;
using InfinityBeyondControllers1.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfinityBeyondControllers1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KorisnikControllers : ControllerBase
    {

        private readonly InfinityBeyondContext _context;

        public KorisnikControllers(InfinityBeyondContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return new JsonResult(_context.Korisnik.ToList());
        }

        [HttpPost]
        public IActionResult Post(Korisnik korisnik)
        {
            _context.korisnik.Add(korisnik);
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
            // Brisanje u bazi
            return StatusCode(StatusCodes.Status200OK, "{\"obrisano\":true}");
        }
    }
}