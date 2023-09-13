using InfinityBeyondControllers;
using InfinityBeyondControllers.Data;
using InfinityBeyondControllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Linq.Expressions;

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

        /// <summary>
        /// Dohvaća sve Korisnike iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    GET api/v1/Smjer
        ///
        /// </remarks>
        /// <returns>Smjerovi u bazi</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 

        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //kontrola ako  nije dobar
            }
            try
            {
                var korisnici = _context.Korisnik.ToList();
                if (korisnici == null || korisnici.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(_context.Korisnik.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }
        /// <summary>
        /// Mijenja podatke postojećeg Korisnika u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/smjer/1
        ///
        /// {
        ///  "id": 0,
        ///  "ime": baton,
        ///  "prezime": karoic,
        ///  "oib": 9384958675,
        ///  "email": 123@gmail.com,
        /// }
        ///
        /// </remarks>
        /// <param name="id">id korisnika koji se mijenja</param>  
        /// <returns>Svi poslani podaci od korisnika</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi korisnika kojeg želimo promijeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 

        [HttpPost]
        public IActionResult Post(Korisnik korisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                _context.Korisnik.Add(korisnik);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, korisnik);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


        /// <summary>
        /// Mijenja podatke postojećeg korisnika u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/smjer/1
        ///
        /// {
        ///  "id": 0,
        ///  "ime": baton,
        ///  "prezime": karoic,
        ///  "oib": 9384958675,
        ///  "email": 123@gmail.com,
        /// }
        ///
        /// </remarks>
        /// <param name="id">id korisnika koji se mijenja</param>  
        /// <returns>Svi poslani podaci od korisnika</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi smjera kojeg želimo promijeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Korisnik korisnik)
        {

            if (sifra <= 0 || korisnik == null)
            {

                return BadRequest();
            }
            try
            {
                var KorisnikBaza = _context.Korisnik.Find(sifra);
                if (KorisnikBaza == null)
                {
                    return BadRequest();
                }
                KorisnikBaza.ime = korisnik.ime;
                KorisnikBaza.prezime = korisnik.prezime;
                KorisnikBaza.oib = korisnik.oib;
                KorisnikBaza.email = korisnik.email;

                _context.Korisnik.Update(KorisnikBaza);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, KorisnikBaza);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex);
            }


        }
        /// <summary>
        /// Briše korisnika iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    DELETE api/v1/smjer/1
        ///    
        /// </remarks>
        /// <param name="id">id korisnika koji se briše</param>  
        /// <returns>Odgovor da li je obrisano ili ne</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi korisnika kojeg želimo obrisati</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 
        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            if (sifra <= 0)
            {
                return BadRequest();
            }

            var korisnikBaza = _context.Korisnik.Find(sifra);
            if (korisnikBaza == null)
            {
                return BadRequest();
            }

            try
            {
                _context.Korisnik.Remove(korisnikBaza);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\":\"Obrisano\"}");

            }
            catch (Exception ex)
            {

                return new JsonResult("{\"poruka\":\"Ne može se obrisati\"}");

            }
        }

    }  
}