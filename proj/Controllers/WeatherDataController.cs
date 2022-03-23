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
    public class WeatherDataController : ControllerBase
    {

        public WAirContext Context { get; set; }

        public WeatherDataController(WAirContext context)
        {
            Context = context;
        }

        [Route("addweatherdata")]
        [HttpPost]
        public async Task<ActionResult> AddWeatherData([FromBody] Weatherdata wdata)
        {
            if (string.IsNullOrWhiteSpace(wdata.Ukratko))
            {
                return BadRequest("Ne sadrzi opis vremena.");
            }

            try
            {
                Context.weatherdatas.Add(wdata);
                await Context.SaveChangesAsync();
                return Ok("Podaci o vremena su dodati.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("getweatherdata")]
        [HttpGet]
        public async Task<ActionResult> GetWeatherData()
        {
            try
            {
                return Ok(await Context.weatherdatas.ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("deleteweatherdata")]
        [HttpDelete]
        public async Task<ActionResult> DeleteWeatherData(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Pogrešan ID!");
            }

            try
            {
                var usluga = await Context.weatherdatas.FindAsync(id);
                if(usluga != null)
                {
                    Context.weatherdatas.Remove(usluga);
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