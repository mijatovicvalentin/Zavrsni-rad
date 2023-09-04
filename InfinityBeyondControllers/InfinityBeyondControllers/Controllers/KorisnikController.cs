using InfinityBeyondControllers.Models;
using InfinityBeyondControllers.Data;
using Microsoft.AspNetCore.Mvc;

namespace InfinityBeyondControllers.Controllers
{

    [ApiController]
    [Route("Controller")]
   

    public class KorisnikController : ControllerBase    
    {


        /// <summary>
        /// Ruta dohvaća sve smjerove u bazi
        /// </summary>
        /// <returns>Lista smjerova</returns>
        ///

        private readonly InfinityBeyondContext _context;

        public KorisnikController(InfinityBeyondContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {

       


            return new JsonResult(_context.korisnik.ToList());

        }



        [HttpPost]
        public IActionResult Post(KorisnikController korisnik)
        {

            _context.korisnik.Add(korisnik);
            _context.SaveChanges();



            return Created("/api&v1/korisnik", korisnik);

        }



        [HttpPut]
        [Route("sifra:int")]
        public IActionResult Put(int sifra, KorisnikController korisnik)
        {

            return StatusCode(StatusCodes.Status200OK, korisnik);
        }



        [HttpDelete]
        [Route("sifra:int")]
        [Produces("application/json")]

        public IActionResult Delete(int sifra)
        {

            return StatusCode(StatusCodes.Status200OK, "{\"obrisano\":true}");


        }

    }
}
