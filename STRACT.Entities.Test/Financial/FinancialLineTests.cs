using STRACT.Entities.Financial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace STRACT.Entities.Test.Financial
{
    public class FinancialLineTests
    {
        [Theory]
        [InlineData(10, 1.5, 10*1.5)]
        [InlineData(20, 0.5, 20*0.5)]
        public void AdjudicatedValue_ExchangeRateIsCorrect(double currencyValue, double exchangeRateValue, double result)
        {
            FinancialLine line = new FinancialLine { AdjudicatedValueOriginalCurrency = currencyValue, ExchangeRateToEuro = exchangeRateValue };

            Assert.Equal(result, line.AdjudicatedValueInEuro);
        }
        [Fact]
        public void AdjudicatedValue_NegativeValues()
        {
            FinancialLine line = new FinancialLine { AdjudicatedValueOriginalCurrency = -10, ExchangeRateToEuro = 0.5 };

            Assert.Throws<Exception>(() => line.AdjudicatedValueInEuro);
        }
    }
}
