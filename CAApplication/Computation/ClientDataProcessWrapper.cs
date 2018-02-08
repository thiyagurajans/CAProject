using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Computation
{
    class ClientDataProcessWrapper
    {
        public static string calculateReceiptPayment(ClientDataProcessor objClientDataProcessor)
        {
            return objClientDataProcessor.computeIncomeAndExpenditure();
        }
        public static string calculateIncomeExpenditure(ClientDataProcessor objClientDataProcessor)
        {
            return objClientDataProcessor.computeIncomeAndExpenditure();
        }
        public static string calculateCapital(ClientDataProcessor objClientDataProcessor)
        {
            return objClientDataProcessor.computationOfCapital();
        }
    }
}
