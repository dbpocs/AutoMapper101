using AutoMapper;
using AutoMApper101.Application.Commands;
using System;
using Xunit;

namespace AutoMapper101.UnitTest
{
    public class MapperProfileTest
    {
        [Fact]
        public void IsValidConfiguration()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void ShouldMapAgeToYearOfBirth()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            var mapper = configuration.CreateMapper();
            var result = mapper.Map<SampleDTOOut>(new DoMappingCommand
            {
                SampleDTOIn = new SampleDTOIn
                {
                    Age = 3
                }
            });

            Assert.Equal(DateTime.Now.Year - 3, result.YearOfBirth.Value);
        }
    }
}