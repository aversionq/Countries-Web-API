using System;
using System.Collections.Generic;
using System.Text;
using CountriesApp.BLL.Models;

namespace CountriesApp.BLL.Tests
{
    internal class CountriesBLLTestsInitializer
    {
        public IEnumerable<CountryDTO> TestData { get; private set; }

        public void Initialize()
        {
            TestData = new List<CountryDTO>
            {
                new CountryDTO { Id = Guid.Parse("A313E6EF-B18B-4EAF-8B89-24B2C1A86D0D"),
                                Area = 7674,
                                Population = 945839,
                                Capital = "Test1",
                                Name = "TestName",
                                Density = 945839 / 7674},

                new CountryDTO { Id = Guid.Parse("{915398DF-AAD8-4ACB-A91D-7DC774C6D786}"),
                                 Area = 123,
                                 Capital = "Test2",
                                 Name = "NameTest",
                                 Population = 326745,
                                 Density = 326745 / 123 }
            };
        }
    }
}
