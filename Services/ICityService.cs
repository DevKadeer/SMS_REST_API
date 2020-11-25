using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMS_REST_API.Models;

namespace SMS_REST_API.Services
{
    interface ICityService
    {
        public ICollection<CityModel> GetAll();
    }
}
