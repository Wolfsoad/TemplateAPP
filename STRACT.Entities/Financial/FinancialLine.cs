using STRACT.Entities.CommissionProposals;
using STRACT.Entities.General;
using STRACT.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Entities.Financial
{
    public class FinancialLine
    {
        public int FinancialLineId { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string InvestmentOrder { get; set; }
        public string InvestmentCode { get; set; }
        public string ExpenseAccount { get; set; }
        public double BudgetValue { get; set; }
        public double AdjudicatedValueOriginalCurrency { get; set; }
        public double ExchangeRateToEuro { get; set; }
        public double AccountedValue { get; set; }
        public string Claim { get; set; }
        public string PurchaseOrder { get; set; }
        public string PurchaseRequest { get; set; }
        public string ProductionOrder { get; set; }
        public string Invoice { get; set; }
        public string ServiceAcceptance { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int ActionItemId { get; set; }
        public ActionItem ActionItem { get; set; }
        public int ProposalId { get; set; }
        public Proposal Proposal { get; set; }
        public int FinancialLineTypeId { get; set; }
        public FinancialLineType FinancialLineType { get; set; }
        public int FinancialLineSubtypeId { get; set; }
        public FinancialLineSubType FinancialLineSubType { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        
        //Private methods
        private void GetAccountedValueInApplicationCurrency()
        {
            
        }
    }
}
