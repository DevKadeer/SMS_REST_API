using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SMS_REST_API.Models;

namespace SMS_REST_API.DataAccess
{
    public class DbInitializer
    {
        public static void Initialize(CityContext context)
        {
            context.Database.EnsureCreated();

            // Look for any city.
            if (context.CityDbSet.Any())
            {
                return;   // DB has been seeded
            }

            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), "data.json");
            var cityJson = File.ReadAllText(folderDetails);
            var cities = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CityModel>>(cityJson);

            foreach (var c in cities)
            {
                context.CityDbSet.Add(c);

                //context.CityData.Add(new CityDataModel()
                //{
                //    City = c.City,
                //    Color = c.Color,
                //    End_Date = DateTime.ParseExact(c.End_Date, "M/d/yyyy", null),
                //    Start_Date = DateTime.ParseExact(c.Start_Date, "M/d/yyyy", null),
                //    Id = c.Id,
                //    Price = c.Price,
                //    Status = c.Status
                //});
            }

            context.SaveChanges();
        }
    }
}