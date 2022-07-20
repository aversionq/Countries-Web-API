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
    public class CountriesBLL : ICountriesBLL
    {
        private ICountriesDAL _DAL;
        private Mapper _countriesMapper;

        public CountriesBLL()
        {
            _DAL = new CountriesDAL();
            var countriesConfig = new MapperConfiguration(cfg => cfg.CreateMap<Country, CountryDTO>().ReverseMap());

            _countriesMapper = new Mapper(countriesConfig);
        }

        public void AddCountry(CountryDTO country)
        {
            var countryToAdd = _countriesMapper.Map<CountryDTO, Country>(country);
            countryToAdd.Id = Guid.NewGuid();

            _DAL.AddCountry(countryToAdd);
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
            countriesModels.ForEach(country => country.CountDensity());

            return countriesModels;
        }

        public CountryDTO GetCountry(Guid id)
        {
            var countryEntity = _DAL.GetCountry(id);
            var countryModel = _countriesMapper.Map<Country, CountryDTO>(countryEntity);
            countryModel?.CountDensity();

            return countryModel;
        }

        public CountryDTO GetCountry(string name)
        {
            var countryEntity = _DAL.GetCountry(name.ToLower());
            var countryModel = _countriesMapper.Map<Country, CountryDTO>(countryEntity);
            countryModel?.CountDensity();

            return countryModel;
        }

        public void UpdateCountry(CountryDTO country)
        {
            var countryEntity = _countriesMapper.Map<CountryDTO, Country>(country);
            _DAL.UpdateCountry(countryEntity);
        }
    }
}
