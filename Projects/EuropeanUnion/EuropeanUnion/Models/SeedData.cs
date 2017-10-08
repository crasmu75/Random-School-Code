using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EuropeanUnion.Models
{
    public class SeedData : DropCreateDatabaseIfModelChanges<CountryContext>
    {
        protected override void Seed(CountryContext context)
        {
            new List<Country> {
                new Country { Name = "Austria", PoliticalSystem = "Federal Republic", Area = 83870, Population = 8300000 },
                new Country { Name = "Belgium", PoliticalSystem = "Constitutional Monarchy", Area = 30528, Population = 10700000 },
                new Country { Name = "Bulgaria", PoliticalSystem = "Republic", Area = 111910, Population = 7600000 },
                new Country { Name = "Cyprus", PoliticalSystem = "Republic", Area = 9250, Population = 800000 },
                new Country { Name = "Czech Republic", PoliticalSystem = "Republic", Area = 78866, Population = 10500000 },
                new Country { Name = "Denmark", PoliticalSystem = "Constitutional Monarchy", Area = 43094, Population = 5500000 },
                new Country { Name = "Estonia", PoliticalSystem = "Republic", Area = 45000, Population = 1300000 },
                new Country { Name = "Finland", PoliticalSystem = "Republic", Area = 338000, Population = 5300000 },
                new Country { Name = "France", PoliticalSystem = "Republic", Area = 550000, Population = 64300000 },
                new Country { Name = "Germany", PoliticalSystem = "Federal Republic", Area = 356854, Population = 82000000 },
                new Country { Name = "Greece", PoliticalSystem = "Republic", Area = 131957, Population = 11200000 },
                new Country { Name = "Hungary", PoliticalSystem = "Republic", Area = 93000, Population = 10000000 },
                new Country { Name = "Irland", PoliticalSystem = "Republic", Area = 70000, Population =  4500000},
                new Country { Name = "Italy", PoliticalSystem = "Republic", Area = 301263, Population = 60000000 },
                new Country { Name = "Latvia", PoliticalSystem = "Republic", Area = 65000, Population = 2300000 },
                new Country { Name = "Lithuania", PoliticalSystem = "Republic", Area = 65000, Population = 3300000 },
                new Country { Name = "Luxembourg", PoliticalSystem = "Constitutional Monarchy", Area = 2586, Population = 500000 },
                new Country { Name = "Malta", PoliticalSystem = "Republic", Area = 316, Population = 400000 },
                new Country { Name = "Netherlands", PoliticalSystem = "Constitutional Monarchy", Area = 41526, Population = 16400000 },
                new Country { Name = "Poland", PoliticalSystem = "Republic", Area = 312679, Population = 38100000 },
                new Country { Name = "Portugal", PoliticalSystem = "Republic", Area = 92072, Population = 10600000 },
                new Country { Name = "Romania", PoliticalSystem = "Republic", Area = 237500, Population = 21500000 },
                new Country { Name = "Slovakia", PoliticalSystem = "Republic", Area = 48845, Population = 5400000 },
                new Country { Name = "Slovenia", PoliticalSystem = "Republic", Area = 20273, Population = 2000000 },
                new Country { Name = "Spain", PoliticalSystem = "Constitutional Monarchy", Area = 504782, Population = 45800000 },
                new Country { Name = "Sweden", PoliticalSystem = "Constitutional Monarchy", Area = 449964, Population = 9200000 },
                new Country { Name = "United Kingdom", PoliticalSystem = "Constitutional Monarchy", Area = 244820, Population = 61700000 }
            }.ForEach(c => context.Countries.Add(c));
        }
    }
}