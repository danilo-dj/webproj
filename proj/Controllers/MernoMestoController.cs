using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.EntityFrameworkCore;

namespace proj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MernoMestoController : ControllerBase
    {
        public WAirContext Context { get; set; }

        public MernoMestoController(WAirContext context)
        {
            Context = context;
        }
        
        [Route("updateweatherdata/{imemernogmesta}/{opis}/{temperature}/{humidity}")]
        [HttpPut]
        public async Task<ActionResult> UpdateWeatherData(string imemernogmesta, string opis, double temperature,double humidity)
        {
            if (opis.Length > 50 == true)
            {
                return BadRequest("Predugacak opis.");
            }

            try
            {
                var mernomesto = Context.mernamesta.Where(p => p.Ime == imemernogmesta).FirstOrDefault();
                var weatherdata = Context.weatherdatas.Where(p => p.ID == mernomesto.ID).FirstOrDefault();

                if (weatherdata != null)
                {
                    weatherdata.Temperature = temperature;
                    weatherdata.Humidity= humidity;
                    weatherdata.Ukratko= opis;

                    Context.weatherdatas.Update(weatherdata);

                    await Context.SaveChangesAsync();
                    return Ok("Uspešno izmenjeni podaci.");
                }
                else
                {
                    return BadRequest("Doslo je do greske!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("updateairqdata/{imemernogmesta}/{qindex}/{pmtwo}")]
        [HttpPut]
        public async Task<ActionResult> UpdateAirQData(string imemernogmesta, int qindex, double pmtwo)
        {
            if (qindex < 0 == true || pmtwo < 0 == true)
            {
                return BadRequest("Neispravni podaci.");
            }

            try
            {
                var mernomesto = Context.mernamesta.Where(p => p.Ime == imemernogmesta).FirstOrDefault();
                var airqdata = Context.airqdatas.Where(p => p.ID == mernomesto.ID).FirstOrDefault();
                if(mernomesto == null)
                {
                    return BadRequest("Merno mesto ne postoji u bazi!");
                }
                airqdata.PMtwo= pmtwo;
                airqdata.Qindex =qindex;

                Context.airqdatas.Update(airqdata);

                await Context.SaveChangesAsync();
                return Ok("Uspešno izmenjeni podaci.");                
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("adddata")]
        [HttpPost]
        public async Task<ActionResult> AddData([FromBody] MernoMesto mernomesto)
        {
            if (string.IsNullOrEmpty(mernomesto.Ime) || mernomesto.weatherdata.Humidity < 0 == true
                 || string.IsNullOrEmpty(mernomesto.weatherdata.Ukratko) || mernomesto.airqdata.PMtwo < 0 == true
                 || mernomesto.airqdata.Qindex < 0 == true)
            {
                return BadRequest("Neispravni podaci.");
            }

            try
            {
                var c = await Context.citymuns.Where(p=> p.Ime == mernomesto.citymun.Ime).FirstOrDefaultAsync();
                mernomesto.citymun = c;                
                Context.mernamesta.Add(mernomesto);
                
                await Context.SaveChangesAsync();
                return Ok("Uspesno dodavanje podataka.");                        
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("getdata/{imemernogmesta}")]
        [HttpGet]

        public async Task<ActionResult> GetData ( string imemernogmesta)
        {
            if(string.IsNullOrEmpty(imemernogmesta))
            {
                return BadRequest("Neispravni podaci.");
            }

            try
            {
                var c = await Context.mernamesta
                                .Include(p => p.weatherdata)
                                .Include(p => p.airqdata)
                                .Include(p => p.citymun)
                                .Where(p => p.Ime == imemernogmesta).FirstOrDefaultAsync();

                return Ok(c);               
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("deletemesto/{imemernogmesta}")]
        [HttpDelete]
        public async Task<ActionResult> OtkaziTermin(string imemernogmesta)
        {
            if (string.IsNullOrEmpty(imemernogmesta))
            {
                return BadRequest("Pogresno ime!");
            }

            try
            {
                var m = await Context.mernamesta.Where(p => p.Ime == imemernogmesta).FirstOrDefaultAsync();
                Context.mernamesta.Remove(m);
                await Context.SaveChangesAsync();
                return Ok("Uspešno obrisano merno mesto.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("updatemesto/{imemesta}/{fid}")]
        [HttpPut]        
        public async Task<ActionResult> UpdateMesto(string imemesta, int fid)
        {
            if (string.IsNullOrWhiteSpace(imemesta) || fid < 0)
            {
                return BadRequest("Neispravni podaci.");
            }

            try
            {
                var m = await Context.mernamesta.Where(p => p.Ime == imemesta).FirstOrDefaultAsync();
                var citymun = await Context.citymuns.FindAsync(fid);
                if(citymun != null)
                {
                    m.citymun = citymun;
                }
                Context.mernamesta.Update(m);
                await Context.SaveChangesAsync();
                return Ok("Podaci o vremena su dodati.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}