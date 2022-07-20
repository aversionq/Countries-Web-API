using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountriesApp.BLL;
using CountriesApp.BLL.Interfaces;
using CountriesApp.BLL.Models;
using CountriesApp.API.Tools;

namespace CountriesApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private ICountriesBLL _BLL;
        private CountriesControllerHelper _countriesControllerHelper;

        public CountriesController()
        {
            _BLL = new CountriesBLL();
            _countriesControllerHelper = new CountriesControllerHelper();
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
        public IActionResult AddCountry([FromBody] CountryDTO country)
        {
            _BLL.AddCountry(country);
            return Ok();
        }

        /// <summary>
        /// Finds country in database by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Existing Country instance</returns>
        [HttpGet]
        [Route("getCountryById")]
        public ActionResult<CountryDTO> GetCountry(Guid id)
        {
            var country = _BLL.GetCountry(id);

            if (!_countriesControllerHelper.IsCountry(country))
            {
                return NotFound("There is no country in the database with such id.");
            }

            return Ok(country);
        }

        /// <summary>
        /// Finds country in database by its name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Existing Country instance</returns>
        [HttpGet]
        [Route("getCountryByName")]
        public ActionResult<CountryDTO> GetCountry(string name)
        {
            var country = _BLL.GetCountry(name);

            if (!_countriesControllerHelper.IsCountry(country))
            {
                return NotFound("There is no country in the database with such name.");
            }

            return Ok(country);
        }

        /// <summary>
        /// Updates existing Country instance.
        /// </summary>
        /// <param name="country"></param>
        [HttpPut]
        [Route("updateCountry")]
        public IActionResult UpdateCountry(CountryDTO country)
        {
            _BLL.UpdateCountry(country);
            return Ok();
        }

        /// <summary>
        /// Deletes Country instance by its id.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("deleteCountry")]
        public IActionResult DeleteCountry(Guid id)
        {
            var countryToDelete = _BLL.GetCountry(id);

            if (!_countriesControllerHelper.IsCountry(countryToDelete))
            {
                return NotFound("There is no country in the database with such id.");
            }

            _BLL.DeleteCountry(id);
            return Ok();
        }
    }
}
