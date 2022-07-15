using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CountriesApp.DAL.Entities;
using CountriesApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CountriesApp.DAL
{
    public class CountriesDAL : ICountriesDAL
    {
        private CountriesDbContext _dbContext;

        public CountriesDAL()
        {
            _dbContext = new CountriesDbContext();
        }

        public void AddCountry(Country country)
        {
            _dbContext.Add(country);
            _dbContext.SaveChangesAsync();
        }

        public void DeleteCountry(Country country)
        {
            _dbContext.Entry(country).State = EntityState.Deleted;
            _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Country> GetCountries() => _dbContext.Countries.ToList();

        public Country GetCountry(Guid id) => _dbContext.Countries.Where(x => x.Id == id).FirstOrDefault();

        public Country GetCountry(string name) => _dbContext.Countries.Where(x => x.Name == name).FirstOrDefault();

        public void UpdateCountry(Country country)
        {
            _dbContext.Update(country);
            _dbContext.SaveChangesAsync();
        }
    }
}
