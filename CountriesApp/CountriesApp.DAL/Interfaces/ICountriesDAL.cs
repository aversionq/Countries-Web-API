using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CountriesApp.DAL.Entities;

namespace CountriesApp.DAL.Interfaces
{
    interface ICountriesDAL
    {
        public IQueryable<Country> GetCountries();
        public Country GetCountry(Guid id);
        public Country GetCountry(string name);
        public void AddCountry(Country country);
        public void DeleteCountry(Guid id);
        public void UpdateCountry(Country country);
    }
}
