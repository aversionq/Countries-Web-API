using System;
using CountriesApp.DAL.Interfaces;
using CountriesApp.DAL;
using CountriesApp.BLL.Interfaces;
using CountriesApp.BLL;

namespace CountriesApp.Dependencies
{
    public class DependencyResolver
    {
        #region Singleton
        private static DependencyResolver _instance;

        public static DependencyResolver Instance => _instance ??= new DependencyResolver();

        private DependencyResolver() { }
        #endregion

        private ICountriesDAL _countriesDAL;
        public ICountriesDAL CountriesDAL => _countriesDAL ??= new CountriesDAL();

        private ICountriesBLL _countriesBLL;
        public ICountriesBLL CountriesBLL => _countriesBLL ??= new CountriesBLL(CountriesDAL);
    }
}
