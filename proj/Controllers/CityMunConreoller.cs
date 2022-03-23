using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace proj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityMunController : ControllerBase
    {
        public WAirContext Context { get; set; }

        public CityMunController(WAirContext context)
        {
            Context = context;
        }

        [Route("addcitymun")]
        [HttpPost]
        public async Task<ActionResult> AddCityMun([FromBody] CityMun citymun)
        {
            if (string.IsNullOrWhiteSpace(citymun.Ime) || string.IsNullOrEmpty(citymun.ZIPcode))
            {
                return BadRequest("Neispravni podaci");
            }

            try
            {
                Context.citymuns.Add(citymun);
                await Context.SaveChangesAsync();
                return Ok("Podaci o gradu/opstini su dodati.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("getcitymun")]
        [HttpGet]
        public async Task<ActionResult> GetCityMun()
        {
            try
            {
                return Ok(await Context.citymuns.ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("getcitymunmesta/{city}")]
        [HttpGet]
        public async Task<ActionResult> GetCityMunMesta(string city)
        {
            try
            {
                var c = await Context.citymuns
                                .Include(p => p.mernamesta)                                
                                .Where(p => p.Ime == city)
                                .Select(p => p.mernamesta)
                                .FirstOrDefaultAsync();
                
                return Ok(c);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("getcitymunid/{imegrada}")]
        [HttpGet]
        public async Task<ActionResult> GetCityMunId(string imegrada)
        {
            try
            {
                var c = await Context.citymuns                                                                
                                .Where(p => p.Ime == imegrada)                                
                                .FirstOrDefaultAsync();
                
                return Ok(c);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("deletecitymun")]
        [HttpDelete]
        public async Task<ActionResult> DeleteCityMun(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Pogrešan ID!");
            }

            try
            {
                var citymun = await Context.citymuns.FindAsync(id);
                if (citymun != null)
                {
                    Context.citymuns.Remove(citymun);
                    await Context.SaveChangesAsync();
                    return Ok("Uspešno izbrisani podaci.");
                }
                else
                {
                    return BadRequest("Podaci za brisanje ne postoje u bazi!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




    }
}