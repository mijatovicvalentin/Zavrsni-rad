using Microsoft.AspNetCore.Mvc;

namespace InfinityBeyondControllers.Controllers
{

    [ApiController]
    [Route("Controller1")]
    public class uslugaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get1()
        {

            var LIST = new List<Usluga>()
            {
                new (){Naziv="Moyaz"},
                new (){Destinacija="Mars"},
                new (){NacinPlacanja=1},
                new (){Cijena=928112},  
                new (){BrojMjesta=28}


            };

            return new JsonResult(LIST);
        }

        [HttpPut]
        public IActionResult Post2(Usluga usluga)
        {

            return Created("\api&v1/usluga", usluga);

        }


        [HttpPost]
        [Route("int:sifra")]
        public IActionResult Put3(int sifra,string usluga)
        {

            return StatusCode(StatusCodes.Status200OK, usluga);

        }


        [HttpDelete]
        [Route("int:sifra")]
        [Produces("application/json")]


        public IActionResult Delete4(int sifra)
        {

            return StatusCode(StatusCodes.Status200OK, "{\"obrisano\":true}");

        }
    }
}
