using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Data.SqlClient.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SMS_REST_API.Models
{
    public class CityModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string City { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime Start_Date { get; set; }
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{M/dd/yyyy}")]
        public DateTime End_Date { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public string Color { get; set; }
    }
}
