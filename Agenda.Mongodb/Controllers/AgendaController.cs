using Agenda.Framework.Model;
using Agenda.Mongodb.Service;
using Amazon.Runtime.Internal.Util;
using Framework.Agenda.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Agenda.Mongodb.Controllers
{
    [ApiController]
    [Route("/api/agenda/")]
    public class AgendaController : ControllerBase
    {
        private readonly ILogger<AgendaController> _logger;
        private readonly IAgendaService agendaService;
        private readonly IMemoryCache cache;

        public AgendaController(ILogger<AgendaController> logger, IAgendaService agendaService, IMemoryCache cache)
        {
            _logger = logger;
            this.agendaService = agendaService;
            this.cache = cache;
        }

        /*[HttpGet(Name = "GetEventsByDate")]
        public string Get()
        {
            return null;
        }*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date">Data fromat = dd-MM-yyyy</param>
        /// <returns></returns>
        [HttpGet("events/{date}")]
        [ProducesResponseType(typeof(List<BsonAgenda>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByEventDateAsync([FromRoute] string date)
        {
            try
            {
                var key = $"GetEvents-{date}";

                return await cache.GetOrCreate(key, async entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(4);
                    entry.SetPriority(CacheItemPriority.High);

                    return Ok(await agendaService.GetEventsbyDateAsync(date));
                });
            }
            catch (DataNotFoundException)
            {
                return NotFound($"No data was found on mongodb for date {date.ToString()}");
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpPost("events/create")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostEvent([FromBody] AgendaDto bson)
        {
            try
            {
                await agendaService.InsertEventAsync(bson);
                return Ok();
            }
            catch (MongodbException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }
    }
}