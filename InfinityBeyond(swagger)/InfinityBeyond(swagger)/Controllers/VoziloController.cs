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
