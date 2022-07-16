using System;
using System.Collections.Generic;
using System.Text;
using CountriesApp.BLL.Interfaces;
using CountriesApp.BLL.Models;
using CountriesApp.DAL.Entities;
using CountriesApp.DAL.Interfaces;
using CountriesApp.DAL;
using AutoMapper;
using System.Linq;

namespace CountriesApp.BLL
{
    class CountriesBLL : ICountriesBLL
    {
        private ICountriesDAL _DAL;
        private Mapper _countriesMapper;

        CountriesBLL()
        {
            _DAL = new CountriesDAL();
            var countriesConfig = new MapperConfiguration(cfg => cfg.CreateMap<Country, CountryDTO>().ReverseMap());

            _countriesMapper = new Mapper(countriesConfig);
        }

        public void AddCountry(CountryDTO country)
        {
            var countryToAdd = _countriesMapper.Map<CountryDTO, Country>(country);

            _DAL.AddCountry(countryToAdd);
        }

        public void CountDensity(CountryDTO country)
        {
            country.Density = country.Population / country.Area;
        }

        public void DeleteCountry(Guid id)
        {
            var countryToDelete = new Country { Id = id };

            _DAL.DeleteCountry(countryToDelete);
        }

        public IEnumerable<CountryDTO> GetCountries()
        {
            var countriesEntities = _DAL.GetCountries();
            var countriesModels = _countriesMapper.Map<IEnumerable<Country>, IEnumerable<CountryDTO>>(countriesEntities).ToList();

            countriesModels.ForEach(country => CountDensity(country));

            return countriesModels;
        }

        public CountryDTO GetCountry(Guid id)
        {
            var countryEntity = _DAL.GetCountry(id);
            var countryModel = _countriesMapper.Map<Country, CountryDTO>(countryEntity);
            CountDensity(countryModel);

            return countryModel;
        }

        public CountryDTO GetCountry(string name)
        {
            var countryEntity = _DAL.GetCountry(name.ToLower());
            var countryModel = _countriesMapper.Map<Country, CountryDTO>(countryEntity);
            CountDensity(countryModel);

            return countryModel;
        }

        public void UpdateCountry(CountryDTO country)
        {
            var countryEntity = _countriesMapper.Map<CountryDTO, Country>(country);
            _DAL.UpdateCountry(countryEntity);
        }
    }
}
