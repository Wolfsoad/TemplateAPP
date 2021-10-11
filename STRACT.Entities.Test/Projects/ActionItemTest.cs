using STRACT.Entities.Financial;
using STRACT.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace STRACT.Entities.Test.Projects
{
    public class ActionItemTest
    {
        [Fact]
        public void TotalValueInBudget_TestSum()
        {
            FinancialLine financialLine1 = new() { BudgetValue = 10000 };
            FinancialLine financialLine2 = new() { BudgetValue = 15000 };
            FinancialLine financialLine3 = new() { BudgetValue = 2000 };
            ActionItem actionItem = new()
            {
                FinancialLines = new List<FinancialLine> { financialLine1, financialLine2, financialLine3 }
            };

            Assert.Equal(27000, actionItem.TotalValueInBudget);
        }
        [Fact]
        public void TotalValueAccounted_TestSum()
        {
            FinancialLine financialLine1 = new() { AccountedValue = 10000 };
            FinancialLine financialLine2 = new() { AccountedValue = 15000 };
            FinancialLine financialLine3 = new() { AccountedValue = 2000 };
            ActionItem actionItem = new()
            {
                FinancialLines = new List<FinancialLine> { financialLine1, financialLine2, financialLine3 }
            };

            Assert.Equal(27000, actionItem.TotalValueAccounted);
        }
        [Fact]
        public void TotalValueAccountedByType_TestSum()
        {
            FinancialLine financialLine1 = new() { BudgetValue = 10000, FinancialLineType = new() { Description = "Group1"} };
            FinancialLine financialLine2 = new() { BudgetValue = 15000, FinancialLineType = new() { Description = "Group2" } };
            FinancialLine financialLine3 = new() { BudgetValue = 2000, FinancialLineType = new() { Description = "Group1" } };
            ActionItem actionItem = new()
            {
                FinancialLines = new List<FinancialLine> { financialLine1, financialLine2, financialLine3 }
            };

            Assert.Equal(12000, actionItem.TotalValueInBudgetByType["Group1"]);
            Assert.Equal(15000, actionItem.TotalValueInBudgetByType["Group2"]);
        }
        [Fact]
        public void TotalFinancialLineByType_TestSum()
        {
            FinancialLine financialLine1 = new() { BudgetValue = 10000, FinancialLineType = new() { Description = "Group1" } };
            FinancialLine financialLine2 = new() { BudgetValue = 15000, FinancialLineType = new() { Description = "Group2" } };
            FinancialLine financialLine3 = new() { BudgetValue = 2000, FinancialLineType = new() { Description = "Group1" } };
            ActionItem actionItem = new()
            {
                FinancialLines = new List<FinancialLine> { financialLine1, financialLine2, financialLine3 }
            };

            Assert.Equal(2, actionItem.TotalFinancialLineByType["Group1"].Count);
            Assert.Single(actionItem.TotalFinancialLineByType["Group2"]);
        }
    }
}
