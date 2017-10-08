using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EuropeanUnion.Models
{
    public class Country
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string PoliticalSystem { get; set; }
        public double? Population { get; set; }
        public int? Area { get; set; }
    }
}