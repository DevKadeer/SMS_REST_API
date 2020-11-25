using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SMS_REST_API.DataAccess;
using SMS_REST_API.Models;

namespace SMS_REST_API.Repositories
{
    public class RepoResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class CityRepository : ICityRepository
    {

        private readonly CityContext _context;

        public CityRepository(CityContext context)
        {
            _context = context;
        }

        public async Task<List<CityModel>> GetCities()
        {
            var totalRecords = await _context.CityDbSet.ToListAsync();
            return totalRecords;
        }
        public async Task<List<CityModel>> GetFilteredCities(string filter, string sortOrder, int pageNumber = 0, int pageSize = 10)
        {
            //var validFilter = new PaginationFilter(pageNumber, pageSize);
            var pagedData = await _context.CityDbSet
                .Skip((pageNumber + 1 - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();


            pagedData = sortOrder == "desc"
                ? pagedData.OrderByDescending(x => x.Id).ToList()
                : pagedData.OrderBy(x => x.Id).ToList();
            return pagedData;
        }

        public async Task<CityModel> GetCity(int id)
        {
            var cityModel = await _context.CityDbSet.FindAsync(id);
            return cityModel;
        }

        public async Task<RepoResponse> UpdateCity(CityModel city)
        {
            _context.Entry(city).State = EntityState.Modified;

            bool success;
            string msg;
            try
            {
                await _context.SaveChangesAsync();
                success = true;
                msg = "Add City Success";
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!CityExists(city.Id))
                {
                    success = false;
                    msg = "City not exists";
                }
                else
                {
                    success = false;
                    msg = ex.Message;
                }
            }
            return new RepoResponse
            {
                Success = success,
                Message = msg
            };
        }

        public async Task<RepoResponse> AddCity(CityModel cityModel)
        {
            _context.CityDbSet.Add(cityModel);

            bool success = false;
            string msg = string.Empty;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (CityExists(cityModel.Id))
                {
                    success = false;
                    msg = "City Conflict";
                }
                else
                {
                    success = false;
                    msg = ex.Message;
                }
            }
            return new RepoResponse
            {
                Success = success,
                Message = msg
            };
        }

        public async Task<RepoResponse> DeleteCity(int id)
        {
            bool success = false;
            string msg = string.Empty;

            var cityModel = await _context.CityDbSet.FindAsync(id);
            if (cityModel == null)
            {
                success = false;
                msg = "City not found";
            }

            _context.CityDbSet.Remove(cityModel);
            await _context.SaveChangesAsync();

            return new RepoResponse
            {
                Success = success,
                Message = msg
            };
        }
        public bool CityExists(int id)
        {
            return false;
        }
    }
}
