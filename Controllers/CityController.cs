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
using SMS_REST_API.Repositories;

namespace SMS_REST_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;

        private readonly ICityRepository _cityRepository;
        public CityController(ILogger<CityController> logger, ICityRepository cityRepository)
        {
            _logger = logger;
            _cityRepository = cityRepository;
        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityModel>>> GetAllCities()
        {
            var cities = await _cityRepository.GetCities();

            return Ok(new Response<List<CityModel>>(cities));
        }

        [HttpGet("GetFilteredCities")]
        public async Task<ActionResult<IEnumerable<CityModel>>> GetFilteredCities([FromQuery] string filter, string sortOrder, int pageNumber = 1, int pageSize = 10)
        {
            var cities = await _cityRepository.GetFilteredCities(filter, sortOrder, pageNumber, pageSize);
            return Ok(new PagedResponse<List<CityModel>>(cities, pageNumber, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityModel>> GetCity(int id)
        {
            var city = await _cityRepository.GetCity(id);

            if (city == null)
                return NotFound();

            return city;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityModel cityModel)
        {
            if (id != cityModel.Id)
            {
                return BadRequest();
            }

            var res = await _cityRepository.UpdateCity(cityModel);
            return Ok(new Response<RepoResponse>(res));
        }

        [HttpPost]
        public async Task<ActionResult<CityModel>> AddCity(CityModel cityModel)
        {
            var res = await _cityRepository.AddCity(cityModel);

            return Ok(new Response<RepoResponse>(res));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CityModel>> DeleteCity(int id)
        {
            var res = await _cityRepository.DeleteCity(id);

            return Ok(new Response<RepoResponse>(res));
        }

    }
}
