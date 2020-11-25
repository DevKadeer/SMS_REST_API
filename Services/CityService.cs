using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMS_REST_API.Models;
using SMS_REST_API.Services;

namespace SMS_REST_API.Services
{
    public class CityService : ICityService
    {
        ICollection<CityModel> ICityService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
