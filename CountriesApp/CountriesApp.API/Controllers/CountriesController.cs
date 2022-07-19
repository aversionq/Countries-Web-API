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

        /// <summary>
        /// Returns all countries that are in the database.
        /// </summary>
        /// <returns>List of countries</returns>
        [HttpGet]
        [Route("getCountries")]
        public ActionResult<IEnumerable<CountryDTO>> GetCountries() => Ok(_BLL.GetCountries());

        /// <summary>
        /// Adds new country to database.
        /// </summary>
        /// <param name="country"></param>
        [HttpPost]
        [Route("addCountry")]
        public void AddCountry([FromBody] CountryDTO country)
        {
            _BLL.AddCountry(country);
        }

        /// <summary>
        /// Finds country in database by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Existing Country instance</returns>
        [HttpGet]
        [Route("getCountryById")]
        public ActionResult<CountryDTO> GetCountry(Guid id) => Ok(_BLL.GetCountry(id));

        /// <summary>
        /// Finds country in database by its name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Existing Country instance</returns>
        [HttpGet]
        [Route("getCountryByName")]
        public ActionResult<CountryDTO> GetCountry(string name) => Ok(_BLL.GetCountry(name));

        /// <summary>
        /// Updates existing Country instance.
        /// </summary>
        /// <param name="country"></param>
        [HttpPut]
        [Route("updateCountry")]
        public void UpdateCountry(CountryDTO country)
        {
            _BLL.UpdateCountry(country);
        }

        /// <summary>
        /// Deletes Country instance by its id.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("deleteCountry")]
        public void DeleteCountry(Guid id)
        {
            _BLL.DeleteCountry(id);
        }
    }
}
