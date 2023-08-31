using Microsoft.AspNetCore.Mvc;

namespace InfinityBeyondControllers.Controllers
{

    [ApiController]
    [Route("Controller")]
   

    public class KorisnikController : ControllerBase    
    {

        [HttpGet]
        public IActionResult Get()
        {

            var lIST = new List<Korisnik>()
            {
                new (){Ime="Ime"},
                new (){Prezime="Prezime"},
                new (){Oib=0988679564},
                new (){Email="Mail1878@gmail.com"}


            };

            return new JsonResult(lIST);

        }

        
        [HttpPut]
        public IActionResult Put(Korisnik korisnik)
        {

            return Created("/api&v1/korisnik", korisnik);

        }

        [HttpPost]
        [Route("sifra:int")]
        public IActionResult Post(int sifra, string korisnik)
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
