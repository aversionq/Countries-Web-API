using System;
using System.Collections.Generic;
using System.Text;

namespace CountriesApp.BLL.Models
{
    public class CountryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public double Area { get; set; }
        public int Population { get; set; }
        public double Density { get; set; }
    }
}
