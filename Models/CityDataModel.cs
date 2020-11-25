using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS_REST_API.Models
{
    public class CityDataModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string City { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public string Color { get; set; }
    }
}
