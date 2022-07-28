using System;
using System.Collections.Generic;
using System.Text;
using CountriesApp.DAL.Entities;

namespace CountriesApp.BLL.Tests
{
    internal class CountriesBLLTestsInitializer
    {
        public List<Country> TestData { get; private set; }

        public void Initialize()
        {
            TestData = new List<Country>
            {
                new Country { Id = Guid.Parse("A313E6EF-B18B-4EAF-8B89-24B2C1A86D0D"),
                                Area = 7674,
                                Population = 945839,
                                Capital = "Test1",
                                Name = "TestName" },

                new Country { Id = Guid.Parse("{915398DF-AAD8-4ACB-A91D-7DC774C6D786}"),
                                 Area = 123,
                                 Capital = "Test2",
                                 Name = "NameTest",
                                 Population = 326745 }
            };
        }
    }
}
