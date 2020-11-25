using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SMS_REST_API.DataAccess;
using SMS_REST_API.Models;

namespace SMS_REST_API.Controllers
{
    public class QueryParams
    {

    }

    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;
        private readonly CityContext _context;

        public CityController(ILogger<CityController> logger, CityContext context)
        {
            _logger = logger;
            _context = context;
        }
        //https://localhost:5001/api/city?validFilter=&sortOrder=asc&pageNumber=0&pageSize=3
        // GET: api/CityModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityModel>>> GetAll()
        {
            var totalRecords = await _context.CityDbSet.ToListAsync();
            return Ok(new Response<List<CityModel>>(totalRecords));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CityModel>>> GetCities()
        {
            var totalRecords = await _context.CityDbSet.ToListAsync();
            return Ok(new Response<List<CityModel>>(totalRecords));
        }

        [HttpGet("GetPaged")]
        public async Task<ActionResult<IEnumerable<CityModel>>> GetPagedCities([FromQuery] string filter, string sortOrder, int pageNumber = 1, int pageSize = 10)
        {
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _context.CityDbSet
                .Skip((pageNumber + 1 - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();


            pagedData = sortOrder == "desc"
                ? pagedData.OrderByDescending(x => x.Id).ToList()
                : pagedData.OrderBy(x => x.Id).ToList();
            return Ok(new PagedResponse<List<CityModel>>(pagedData, pageNumber, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityModel>> GetCityModel(int id)
        {
            var cityModel = await _context.CityDbSet.FindAsync(id);

            if (cityModel == null)
            {
                return NotFound();
            }

            return cityModel;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCityModel(int id, CityModel cityModel)
        {
            if (id != cityModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(cityModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CityModel>> PostCityModel(CityModel cityModel)
        {
            _context.CityDbSet.Add(cityModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CityModelExists(cityModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCityModel", new { id = cityModel.Id }, cityModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CityModel>> DeleteCityModel(int id)
        {
            var cityModel = await _context.CityDbSet.FindAsync(id);
            if (cityModel == null)
            {
                return NotFound();
            }

            _context.CityDbSet.Remove(cityModel);
            await _context.SaveChangesAsync();

            return cityModel;
        }

        private bool CityModelExists(int id)
        {
            return _context.CityDbSet.Any(e => e.Id == id);
        }
    }
}
