using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class ClientInputData
    {
        public string InputDesc { get; set; }

        public int CategoryId { get; set; }

        public int FinancialYearId { get; set; }

        public double OpeningBalance { get; set; }

        public double Receipts { get; set; }

        public double PercentageOfPortionSold {get; set;}

        public double Payments {get; set;}

        public double InterestOnCapitalAmount {get; set;}

        public double Remuneration {get; set;}

        public double ShareOfProfitOrLoss {get; set;}

        public double InterestAccrued {get; set;}

        public double InterestReceived {get; set;}

        public double ClosingBalance {get; set;}

        public int IncomeSubCategoryId {get; set;}

        public int ExpenditureSubCategoryId {get; set;}
        
    }
}
