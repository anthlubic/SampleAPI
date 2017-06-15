using System;
using System.Collections.Generic;
using System.Text;
using SampleAPI.Contract.Deals;
using Xunit;

namespace SampleAPI.Tests.Contract
{
    public class DealDtoTest
    {
        [Fact(DisplayName = "DealDto - Deal Price calculates correctly")]
        public void DealPriceCalculatesCorrectly()
        {
            var dealDto = new DealDto
            {
                OriginalPrice = 20.00m,
                PercentOff = 0.25m
            };

            Assert.True(dealDto.DealPrice == 15.00m);
        }

        [Fact(DisplayName = "DealDto - Deal Price has no rounding errors")]
        public void DealPriceHasNoRoundingErrors()
        {
            var dealDto = new DealDto
            {
                OriginalPrice = 19.99m,
                PercentOff = 0.27m
            };

            Assert.True(dealDto.DealPrice == 14.5927m);
        }
    }
}
