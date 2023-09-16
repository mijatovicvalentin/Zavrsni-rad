using InfinityBeyondControllers.Data;
using InfinityBeyondControllers.Models;
using InfinityBeyondControllers.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

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
                        vrsta_djelatnika = v.Vrsta_djelatnika

                    });
                });
                return Ok(vrati);
            }
            catch (Exception ex) { 
            
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex);
            }


        }


        
    }
}