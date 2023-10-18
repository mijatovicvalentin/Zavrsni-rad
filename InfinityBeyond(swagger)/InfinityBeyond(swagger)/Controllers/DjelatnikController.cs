  using InfinityBeyondSwagger.Data;
using InfinityBeyondSwagger.Models;
using InfinityBeyondSwagger.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Data.SqlClient;


namespace InfinityBeyondControllers.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class DjelatnikController : ControllerBase
    {
        private readonly InfinityBeyondContext _context;
        private readonly ILogger<DjelatnikController> _logger;

        public DjelatnikController(InfinityBeyondContext context,
            ILogger<DjelatnikController> logger)
        {
            _context = context;
            _logger = logger;
        }


        /// <summary>
        /// Dohvaća sve djelatnike iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    GET api/v1/Djelatnik
        ///
        /// </remarks>
        /// <returns>djelatnike u bazi</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 

        [HttpGet]
        public IActionResult Get()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var djelatnici = _context.Djelatnik.Include(d => d.Vrsta_djelatnika)
                    .ToList();

                if (djelatnici == null || djelatnici.Count == 0)
                {
                    return new EmptyResult();
                }

                List<DjelatnikDTO> vrati = new();

                djelatnici.ForEach(v =>
                {
                    vrati.Add(new DjelatnikDTO()
                    {
                        id = v.id,
                        ime = v.ime,
                        prezime = v.prezime,
                        oib = v.oib,
                        kontakt = v.kontakt,
                        jedinstvenibroj = v.jedinstvenibroj,
                        vrsta_djelatnika = v.Vrsta_djelatnika.Naziv

                    });
                });
                return Ok(vrati);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex);
            }


        }

        /// <summary>
        /// Mijenja podatke postojećeg djelatnika u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/Djelatnik/1
        ///
        /// {
        ///  "id": 0,
        ///  "ime": baton,
        ///  "prezime": karoic,
        ///  "oib": 9384958675,
        ///  "kontakt": email
        ///  "jedinstvenibroj": 8247
        ///  "vrsta_djelatnika": Pilot
        /// }
        ///
        /// </remarks>
        /// <param name="id">id djelatnika koji se mijenja</param>  
        /// <returns>Svi poslani podaci od korisnika</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi Djelatnika kojeg želimo promijeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 



        [HttpPost]
        public IActionResult Post(DjelatnikDTO djelatnikDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (djelatnikDTO.vd_sifra <= 0)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var vrsta_Djelatnika = _context.Vrsta_Djelatnika.Find(djelatnikDTO.vd_sifra);

                if (vrsta_Djelatnika == null)
                {
                    return BadRequest(ModelState);
                }
                _logger.LogError("Vrsta djelatnika: " +  vrsta_Djelatnika.Naziv);

                Djelatnik d = new()
                {
                    ime = djelatnikDTO.ime,
                    prezime = djelatnikDTO.prezime,
                    oib = djelatnikDTO.oib,
                    kontakt = djelatnikDTO.kontakt,
                    jedinstvenibroj = djelatnikDTO.jedinstvenibroj,
                    Vrsta_djelatnika = vrsta_Djelatnika


                };

                _context.Djelatnik.Add(d);
                _context.SaveChanges();

                djelatnikDTO.vd_sifra = d.id;

                return Ok(djelatnikDTO);


            }
            catch (Exception ex)
            {
                return StatusCode(
                   StatusCodes.Status503ServiceUnavailable,
                   ex);
            }



        }


        /// <summary>
        /// Mijenja podatke postojećeg djelatnika u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/Djelatnik/1
        ///
        /// {
        ///  "id": 0,
        ///  "ime": baton,
        ///  "prezime": karoic,
        ///  "oib": 9384958675,
        ///  "kontakt": email
        ///  "jedinstvenibroj": 8247
        ///  "vrsta_djelatnika": Pilot
        /// }
        ///
        /// </remarks>
        /// <param name="id">id djelatnika koji se mijenja</param>  
        /// <returns>Svi poslani podaci od djelatnika</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi djelatnika kojeg želimo promijeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 
        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, DjelatnikDTO djelatnikDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (sifra <= 0 || djelatnikDTO == null)
            {
                return BadRequest();
            }

            try
            {
                var vrstedjelatnika = _context.Vrsta_Djelatnika.Find(djelatnikDTO.vd_sifra);

                if (vrstedjelatnika == null)
                {
                    return BadRequest();
                }

                var Djelatnik = _context.Djelatnik.Find(sifra);

                if (Djelatnik == null)
                {
                    return BadRequest();
                }

                Djelatnik.ime = djelatnikDTO.ime;
                Djelatnik.prezime = djelatnikDTO.prezime;
                Djelatnik.oib = djelatnikDTO.oib;
                Djelatnik.kontakt = djelatnikDTO.kontakt;
                Djelatnik.jedinstvenibroj = djelatnikDTO.jedinstvenibroj;
                Djelatnik.Vrsta_djelatnika = vrstedjelatnika;

                _context.Djelatnik.Update(Djelatnik);
                _context.SaveChanges();

                djelatnikDTO.vd_sifra = sifra;

                return Ok(djelatnikDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }


        }
        /// <summary>
        /// Briše djelatnike iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    DELETE api/v1/Djelatnik/1
        ///    
        /// </remarks>
        /// <param name="id">id djelatnika koji se briše</param>  
        /// <returns>Odgovor da li je obrisano ili ne</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi djelatnika kojeg želimo obrisati</response>
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

            try
            {
                var djelatnikBaza = _context.Djelatnik.Find(sifra);
                if (djelatnikBaza == null)
                {
                    return BadRequest();
                }
                //napisati provjeru moze li se obrisati

                _context.Djelatnik.Remove(djelatnikBaza);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\":\"Obrisano\"}");

            }
            catch (Exception ex)
            {

                try
                {
                    SqlException sqle = (SqlException)ex;
                    return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                  sqle);
                }
                catch (Exception e)
                {

                }

                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                  ex);
            }
        }


    }
}