using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMS_REST_API.Models;

namespace SMS_REST_API.Repositories
{
    public interface ICityRepository
    {
        Task<List<CityModel>> GetCities();

        Task<List<CityModel>> GetFilteredCities(string filter, string sortOrder, int pageNumber, int pageSize);

        Task<CityModel> GetCity(int cityId);

        Task<RepoResponse> AddCity(CityModel city);

        Task<RepoResponse> UpdateCity(CityModel city);

        Task<RepoResponse> DeleteCity(int cityId);
    }
}
