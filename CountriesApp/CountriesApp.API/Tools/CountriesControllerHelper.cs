using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountriesApp.BLL.Models;

namespace CountriesApp.API.Tools
{
    public class CountriesControllerHelper
    {
        internal bool IsCountry(CountryDTO country)
        {
            if (country == null)
            {
                return false;
            }

            return true;
        }
    }
}
