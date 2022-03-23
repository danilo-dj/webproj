using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace proj.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirQdataController : ControllerBase
    {
        public WAirContext Context { get; set; }

        public AirQdataController(WAirContext context)
        {
            Context = context;
        }

        [Route("addairqdata")]
        [HttpPost]
        public async Task<ActionResult> AddAirQData([FromBody] AirQdata airqdata)
        {
            if (airqdata.Qindex > 0 == true || airqdata.PMtwo > 0 == true)
            {
                return BadRequest("Neispravni podaci.");
            }

            try
            {
                Context.airqdatas.Add(airqdata);
                await Context.SaveChangesAsync();
                return Ok("Podaci o vazduhu su dodati.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}