using InfinityBeyondSwagger.Data;
using InfinityBeyondSwagger.Models;
using InfinityBeyondSwagger.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace InfinityBeyondControllers.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class VoziloController : ControllerBase
    {
        private readonly InfinityBeyondContext _context;
        private readonly ILogger<DjelatnikController> _logger;

        public VoziloController(InfinityBeyondContext context,
            ILogger<DjelatnikController> logger)
        {
            _context = context;
            _logger = logger;
        }


        /// <summary>
        /// Dohvaća sva Vozila iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    GET api/v1/Vozilo   
        ///
        /// </remarks>
        /// <returns>Vozila u bazi</returns>
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
                var vozila = _context.Vozilo.Include(d => d.djelatnik)
                    .ToList();

                if (vozila == null || vozila.Count == 0)
                {
                    return new EmptyResult();
                }

                List<VoziloDTO> vrati = new();

                vozila.ForEach(v =>
                {
                    vrati.Add(new VoziloDTO()
                    {
                        id = v.id,
                        naziv = v.naziv,
                        cijena = v.cijena,
                        datum_proizvodnje = v.datum_proizvodnje,

                        djelatnik = v.djelatnik,
                        tezina = v.tezina

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
        /// Mijenja podatke postojećeg vozila u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/Vozilo/1
        ///
        /// {
        ///  "id": 0,
        ///  "naziv": MirianRover,
        ///  "cijena": 9237.99,
        ///  "datum_proizvodnje": 05.02.2000,
        ///  "djelatnik": 1,
        ///  "tezina": 9826kg,
        /// }
        /// </remarks>
        /// <param name="id">id vozila koji se mijenja</param>  
        /// <returns>Svi poslani podaci od vozila</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi vozila kojeg želimo promijeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 

        [HttpPost]
        public IActionResult Post(VoziloDTO VoziloDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (VoziloDTO.id <= 0)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var djelatnika = _context.Djelatnik.Find(VoziloDTO.djelatnik_sifra);

                if (djelatnika == null)
                {
                    return BadRequest(ModelState);
                }

                Vozilo v = new()
                {
                    naziv = VoziloDTO.naziv,
                    cijena = VoziloDTO.cijena.Value,
                    datum_proizvodnje = VoziloDTO.datum_proizvodnje.Value,
                    djelatnik = djelatnika,
                    tezina = VoziloDTO.tezina


                };

                _context.Vozilo.Add(v);
                _context.SaveChanges();

                VoziloDTO.djelatnik_sifra = v.id;

                return Ok(VoziloDTO);


            }
            catch (Exception ex)
            {
                return StatusCode(
                   StatusCodes.Status503ServiceUnavailable,
                   ex);
            }

        }
        /// <summary>
        /// Mijenja podatke postojećeg vozila u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/Vozilo/1
        ///
        /// {
        ///  "id": 0,
        ///  "naziv": MirianRover,
        ///  "cijena": 9237.99,
        ///  "datum_proizvodnje": 05.02.2000,
        ///  "djelatnik": 1,
        ///  "tezina": 9826kg,
        /// }
        ///
        /// </remarks>
        /// <param name="id">id vozila koji se mijenja</param>  
        /// <returns>Svi poslani podaci od vozila</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi vozila kojeg želimo promijeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 
        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, VoziloDTO voziloDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (sifra <= 0 || voziloDTO == null)
            {
                return BadRequest();
            }

            try
            {
                var djelatnika = _context.Djelatnik.Find(voziloDTO.id);

                if (djelatnika == null)
                {
                    return BadRequest();
                }

                var Vozilo = _context.Vozilo.Find(sifra);

                if (Vozilo == null)
                {
                    return BadRequest();
                }

                Vozilo.naziv = voziloDTO.naziv;
                Vozilo.cijena = voziloDTO.cijena.Value;
                Vozilo.datum_proizvodnje = voziloDTO.datum_proizvodnje.Value;
                Vozilo.tezina = voziloDTO.tezina;
                Vozilo.djelatnik = djelatnika;

                _context.Vozilo.Update(Vozilo);
                _context.SaveChanges();

                voziloDTO.djelatnik_sifra = sifra;

                return Ok(voziloDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }


        }
        /// <summary>
        /// Briše vozilo iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    DELETE api/v1/Vozilo/1
        ///    
        /// </remarks>
        /// <param name="id">id vozila koji se briše</param>  
        /// <returns>Odgovor da li je obrisano ili ne</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi vozila kojeg želimo obrisati</response>
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

                var VoziloBaza = _context.Vozilo.Find(sifra);
                if (VoziloBaza == null)
                {
                    return BadRequest();
                }

                try
                {
                    _context.Vozilo.Remove(VoziloBaza);
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
