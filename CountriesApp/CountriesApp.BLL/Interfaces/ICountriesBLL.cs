using System;
using System.Collections.Generic;
using System.Text;
using CountriesApp.BLL.Models;

namespace CountriesApp.BLL.Interfaces
{
    public interface ICountriesBLL
    {
        public IEnumerable<CountryDTO> GetCountries();
        public CountryDTO GetCountry(Guid id);
        public CountryDTO GetCountry(string name);
        public void AddCountry(CountryDTO country);
        public void DeleteCountry(Guid id);
        public void UpdateCountry(CountryDTO country);
    }
}
