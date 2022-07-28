using System;
using System.Collections.Generic;
using CountriesApp.BLL.Models;
using CountriesApp.DAL.Interfaces;
using Xunit;
using Moq;

namespace CountriesApp.BLL.Tests
{
    public class CountriesBLLTests
    {
        private CountriesBLLTestsInitializer _dataInitializer;

        //TODO: Add more tests.
        [Fact]
        public void GetCountries_Success()
        {
            // Arrange
            _dataInitializer = new CountriesBLLTestsInitializer();
            _dataInitializer.Initialize();

            var mock = new Mock<ICountriesDAL>();
            mock.Setup(x => x.GetCountries()).Returns(_dataInitializer.TestData);
            var bll = new CountriesBLL(mock.Object);

            // Act
            var result = bll.GetCountries();

            // Assert
            var getCountriesResult = Assert.IsType<List<CountryDTO>>(result);
        }

        [Fact]
        public void GetCountry_Success()
        {
            // Arrange
            _dataInitializer = new CountriesBLLTestsInitializer();
            _dataInitializer.Initialize();

            var mock = new Mock<ICountriesDAL>();
            mock.Setup(x => x.GetCountry(new Guid("A313E6EF-B18B-4EAF-8B89-24B2C1A86D0D"))).Returns(_dataInitializer.TestData[0]);
            var bll = new CountriesBLL(mock.Object);

            // Act
            var result = bll.GetCountry(new Guid("A313E6EF-B18B-4EAF-8B89-24B2C1A86D0D"));

            // Assert
            var getCountryResult = Assert.IsType<CountryDTO>(result);
        }
    }
}
