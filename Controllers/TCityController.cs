using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SMS_REST_API.DataAccess;
using SMS_REST_API.Models;

namespace SMS_REST_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;

        private readonly CityContext _context;

        public CityController(ILogger<CityController> logger, CityContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<CityModel> Get()
        {
            var cities = _context.CityDbSet.ToList();
            return cities;
        }

    }
}
