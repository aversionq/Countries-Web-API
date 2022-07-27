using System;
using System.Collections.Generic;
using CountriesApp.BLL.Models;
using CountriesApp.BLL.Interfaces;
using Xunit;
using Moq;

namespace CountriesApp.BLL.Tests
{
    public class CountriesBLLTests
    {
        private CountriesBLLTestsInitializer _dataInitializer;

        //TODO
        [Fact]
        public void GetCountries_Success()
        {
            // Arrange
            _dataInitializer = new CountriesBLLTestsInitializer();
            _dataInitializer.Initialize();

            var mock = new Mock<ICountriesBLL>();
            mock.Setup(bll => bll.GetCountries()).Returns(_dataInitializer.TestData);

            // Act

            // Assert
        }
    }
}
