using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountriesApp.BLL;
using CountriesApp.BLL.Interfaces;
using CountriesApp.BLL.Models;

namespace CountriesApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private ICountriesBLL _BLL;

        public CountriesController()
        {
            _BLL = new CountriesBLL();
        }

        [HttpGet]
        [Route("getCountries")]
        public IEnumerable<CountryDTO> GetCountries() => _BLL.GetCountries();

        [HttpPost]
        [Route("addCountry")]
        public void AddCountry([FromBody] CountryDTO country)
        {
            _BLL.AddCountry(country);
        }

        [HttpGet]
        [Route("getCountryById")]
        public CountryDTO GetCountry(Guid id) => _BLL.GetCountry(id);

        [HttpGet]
        [Route("getCountryByName")]
        public CountryDTO GetCountry(string name) => _BLL.GetCountry(name);

        [HttpPut]
        [Route("updateCountry")]
        public void UpdateCountry(CountryDTO country)
        {
            _BLL.UpdateCountry(country);
        }

        [HttpDelete]
        [Route("deleteCountry")]
        public void DeleteCountry(Guid id)
        {
            _BLL.DeleteCountry(id);
        }
    }
}
