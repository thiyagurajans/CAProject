using System;
using System.Collections.Generic;
using System.Collections;


namespace Computation
{    
    class ClientDataProcessor
    {
        ClientInfo _objClientInfo;
        bool _isPaymentComputeDone;
        bool _isReceiptComputeDone;
        bool _isIncomeComputeDone;
        bool _isExpenditureComputeDone;
        bool _isCapitalAddComputeDone;
        bool _isCapitalLessComputeDone;
        string _lastError;
        public ClientInfo objClientInfo { get { return _objClientInfo; } set { _objClientInfo = objClientInfo; } }
        double _dBusinessIncome;
        public double BusinessIncome { get { return _dBusinessIncome; } set { _dBusinessIncome = BusinessIncome; } }
        double _dBusinessExpenditure;
        public double BusinessExpenditure { get { return _dBusinessExpenditure; } set { _dBusinessExpenditure = BusinessExpenditure; } }
        Hashtable _tblPayment;
        public Hashtable TblPayment { get { return _tblPayment; } set { _tblPayment = TblPayment; } }
        Hashtable _tblReceipt;
        public Hashtable TblReceipt { get { return _tblReceipt; } set { _tblReceipt = TblReceipt; } }
        double _dTotalReceipt;
        public double TotalReceipt { get { return _dTotalReceipt; } set { _dTotalReceipt = TotalReceipt; } }
        Hashtable _tblIncome;
        public Hashtable TblIncome { get { return _tblIncome; } set { _tblIncome = TblIncome; } }
        Hashtable _tblExpenditure;
        public Hashtable TblExpenditure { get { return _tblExpenditure; } set { _tblExpenditure = TblExpenditure; } }
        Hashtable _tblAddCapital;
        public Hashtable TblAddCapital { get { return _tblAddCapital; } set { _tblAddCapital = TblAddCapital; } }
        Hashtable _tblLessCapital;
        public Hashtable TblLessCapital { get { return _tblLessCapital; } set { _tblLessCapital = TblLessCapital; } }

        public ClientDataProcessor(bool paymentDone = false, bool receiptDone = false, bool incomeDone = false, bool expenDone = false,
            bool balaceSheetDone = false, bool capitalAddDone = false, bool capitalLessDone = false, bool firmDone = false)
        {
            _isPaymentComputeDone = paymentDone;
            _isReceiptComputeDone = receiptDone;
            _isIncomeComputeDone = incomeDone;
            _isExpenditureComputeDone = expenDone;
            _isCapitalAddComputeDone = capitalAddDone;
            _isCapitalLessComputeDone = capitalLessDone;
            _lastError = "";
        }
        public List<ClientInputData> findCategoryId(int categoryId, List<ClientInputData> lstClientInputData)
        {
            List<ClientInputData> ret = new List<ClientInputData>();
            foreach (ClientInputData clInputData in lstClientInputData)
            {
                if (clInputData.ClientDataCategory == categoryId)
                {
                    ret.Add(clInputData);
                }
            }
            return ret;
        }
        /*public void addDataInDict(string inLblName, ref Dictionary<string, List<double>> outDict, List<ClientInputData> lstInData, ref double outSum)
        {
            if (lstInData.Count > 0)
            {
                List<double> lstValueOfDict = new List<double>();
                foreach (ClientInputData inputData in lstInData)
                {
                    List<double> existingList;
                    outSum += inputData.OpeningBalance;
                    lstValueOfDict.Add(inputData.OpeningBalance);
                    if (outDict.ContainsKey(inLblName))
                    {
                        existingList = outDict.GetValueOrDefault(inLblName);
                        existingList.Add(inputData.OpeningBalance);
                        outDict.Remove(inLblName);
                        outDict.Add(inLblName, existingList);
                    }
                    else
                    {
                        outDict.Add(inLblName, lstValueOfDict);
                    }

                }
            }

        }*/
        public string computePayments()
        {
            List<ClientInputData> lstClientInputData = _objClientInfo._lstInputData;
            Hashtable opPayment = new Hashtable();
            double dSumOfAllSalaryPayment = 0.0;
            double dSumOfAllRentalPayment = 0.0;
            double dSumOfAllOtherPayment = 0.0;
            double dSumOfAllAgriPayment = 0.0;
            double dSumOfAllPersonalPayment = 0.0;
            List<ClientInputData> subLstClInputData = null;
            double dClosingCapital = 0.0;
            double sumOfPayments = 0;
            if (lstClientInputData != null || lstClientInputData.Count > 0)
            {
                _isPaymentComputeDone = true;
                subLstClInputData = findCategoryId(8, lstClientInputData);
                if (subLstClInputData.Count > 0)
                {
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        if (inputData.ExpenditureSubCategoryId == 1)
                        {
                            dSumOfAllSalaryPayment += inputData.Payments;
                        }
                        else if (inputData.ExpenditureSubCategoryId == 2)
                        {
                            dSumOfAllRentalPayment += inputData.Payments;
                        }
                        else if (inputData.ExpenditureSubCategoryId == 4)
                        {
                            dSumOfAllOtherPayment += inputData.Payments;
                        }
                        else if (inputData.ExpenditureSubCategoryId == 5)
                        {
                            dSumOfAllAgriPayment += inputData.Payments;
                        }
                        else if (inputData.ExpenditureSubCategoryId == 6)
                        {
                            dSumOfAllPersonalPayment += inputData.Payments;
                        }
                    }
                    if (dSumOfAllSalaryPayment > 0)
                    {
                        sumOfPayments += dSumOfAllSalaryPayment;
                        opPayment.Add("SALARY EXPENSES", dSumOfAllSalaryPayment);
                    }
                    if (dSumOfAllRentalPayment > 0)
                    {
                        sumOfPayments += dSumOfAllRentalPayment;
                        opPayment.Add("RENTAL EXPENSES", dSumOfAllRentalPayment);
                    }
                    if (dSumOfAllOtherPayment > 0)
                    {
                        sumOfPayments += dSumOfAllOtherPayment;
                        opPayment.Add("OTHER EXPENSES", dSumOfAllRentalPayment);
                    }
                    if (dSumOfAllAgriPayment > 0)
                    {
                        sumOfPayments += dSumOfAllAgriPayment;
                        opPayment.Add("AGRICULTURAL EXPENSES", dSumOfAllRentalPayment);
                    }
                    if (dSumOfAllPersonalPayment > 0)
                    {
                        sumOfPayments += dSumOfAllPersonalPayment;
                        opPayment.Add("PERSONAL EXPENSES", dSumOfAllPersonalPayment);
                    }
                    if (_dBusinessExpenditure > 0.0)
                    {
                        if (_dBusinessIncome > 0.0)
                        {
                            sumOfPayments += (_dBusinessExpenditure - _dBusinessIncome);
                            opPayment.Add("BUSINESS/PROFESSION LOSS", (_dBusinessExpenditure - _dBusinessIncome));
                        }
                    }
                }
                subLstClInputData = findCategoryId(9, lstClientInputData);
                if (subLstClInputData.Count > 0)
                {
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        opPayment.Add("GIFT PAID(" + inputData.ClientDataName + ")", inputData.Payments);
                        sumOfPayments += inputData.Payments;
                    }
                }
                subLstClInputData = findCategoryId(1, lstClientInputData);
                if (subLstClInputData.Count > 0)
                {
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        opPayment.Add(inputData.ClientDataName, inputData.Payments);
                        sumOfPayments += inputData.Payments;
                    }
                }
                subLstClInputData = findCategoryId(2, lstClientInputData);
                if (subLstClInputData.Count > 0)
                {
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        opPayment.Add(inputData.ClientDataName, inputData.Payments);
                        sumOfPayments += inputData.Payments;
                    }
                }
                subLstClInputData = findCategoryId(3, lstClientInputData);
                if (subLstClInputData.Count > 0)
                {
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        opPayment.Add(inputData.ClientDataName, inputData.Payments);
                        sumOfPayments += inputData.Payments;
                    }
                }
                subLstClInputData = findCategoryId(4, lstClientInputData);
                if (subLstClInputData.Count > 0)
                {
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        opPayment.Add(inputData.ClientDataName, inputData.Payments);
                        sumOfPayments += inputData.Payments;
                    }
                }
                subLstClInputData = findCategoryId(5, lstClientInputData);
                if (subLstClInputData.Count > 0)
                {
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        opPayment.Add("CLOSING BALANCE(" + inputData.ClientDataName + ")", inputData.Payments);
                        sumOfPayments += inputData.Payments;
                    }
                }
                subLstClInputData = findCategoryId(6, lstClientInputData);
                if (subLstClInputData.Count > 0)
                {
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        opPayment.Add(inputData.ClientDataName, inputData.Payments);
                        sumOfPayments += inputData.Payments;
                    }
                }
                dClosingCapital = _dTotalReceipt - sumOfPayments;
                opPayment.Add("TOTAL", dClosingCapital + sumOfPayments);
                TblPayment = opPayment;
                return "1";
            }
            return "no data";
        }
        public string computeReceipt()
        {
            List<ClientInputData> lstClientInputData = _objClientInfo._lstInputData;
            Hashtable opReceipt = new Hashtable();
            bool isBusinessIncomeFound = false;
            bool isBusinessExpenditureFound = false;
            double dSumOfBusinessProfIncome = 0.0;
            double dSumOfBusinessProfExpenditure = 0.0;
            double dBusProfIncomeExp = 0.0;
            double dSumOfDepInterestRcvd = 0.0;
            //ClientInputData inputData;
            //Hashtable ht = new Hashtable();
            List<ClientInputData> subLstClInputData = null;
            string sLblName;
            sLblName = "";
            double sumOfReceipts = 0;
            if (lstClientInputData.Count != 0)
            {
                _isReceiptComputeDone = true;
                subLstClInputData = findCategoryId(1, lstClientInputData);
                if (subLstClInputData.Count > 0)
                {
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        sumOfReceipts += inputData.Receipts;
                        opReceipt.Add(inputData.ClientDataName, inputData.Receipts);
                    }
                }
                subLstClInputData = findCategoryId(2, lstClientInputData);
                if (subLstClInputData.Count > 0)
                {
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        sumOfReceipts += inputData.Receipts;
                        opReceipt.Add(inputData.ClientDataName, inputData.Receipts);
                    }
                }
                subLstClInputData = findCategoryId(3, lstClientInputData);
                if (subLstClInputData.Count > 0)
                {
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        sumOfReceipts += inputData.Receipts;
                        opReceipt.Add(inputData.ClientDataName, inputData.Receipts);
                    }
                }
                subLstClInputData = findCategoryId(6, lstClientInputData);
                if (subLstClInputData.Count > 0)
                {
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        sumOfReceipts += inputData.Receipts;
                        opReceipt.Add(inputData.ClientDataName, inputData.Receipts);
                    }
                }
                subLstClInputData = findCategoryId(10, lstClientInputData);
                if (subLstClInputData.Count > 0)
                {
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        sumOfReceipts += inputData.OpeningBalance;
                        opReceipt.Add("OPENING CASH BANALCE", inputData.OpeningBalance);
                    }
                }
                //Deposit calculations
                subLstClInputData = findCategoryId(4, lstClientInputData);
                //if(clInputData != null && clInputData.OpeningBalance>0)
                if (subLstClInputData.Count > 0)
                {
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        if (inputData.InterestReceived > 0.0)
                        {
                            //sLblName = "DEPOSIT INTEREST INCOME";
                            dSumOfDepInterestRcvd += inputData.InterestReceived;
                        }
                        if (inputData.Receipts > 0.0)
                        {
                            sumOfReceipts += inputData.Receipts;
                            opReceipt.Add(inputData.ClientDataName, inputData.Receipts);
                        }
                    }
                    sumOfReceipts += dSumOfDepInterestRcvd;
                    opReceipt.Add("DEPOSIT INTEREST INCOME", dSumOfDepInterestRcvd);
                }
                subLstClInputData = findCategoryId(5, lstClientInputData);
                //if(clInputData != null && clInputData.OpeningBalance>0)
                if (subLstClInputData.Count > 0)
                {
                    double sumOfSBInterest = 0.0;
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        sumOfReceipts += inputData.OpeningBalance;
                        sLblName = "OPENING BALANCE (" + inputData.ClientDataName + ")";
                        opReceipt.Add(sLblName, inputData.OpeningBalance);
                    }
                    foreach (ClientInputData inputData1 in subLstClInputData)
                    {
                        sumOfSBInterest += inputData1.InterestReceived;
                    }
                    if (sumOfSBInterest > 0.0)
                    {
                        sLblName = "BANK SB INTEREST";
                        opReceipt.Add(sLblName, sumOfSBInterest);
                        sumOfReceipts += sumOfSBInterest;
                    }
                }
                subLstClInputData = findCategoryId(7, lstClientInputData);
                //if(clInputData != null && clInputData.OpeningBalance>0)
                if (subLstClInputData.Count > 0)
                {
                    double dSumOfSalaryIncome = 0.0;
                    double dSumOfRentalIncome = 0.0;
                    double dSumOfOtherIncome = 0.0;
                    double dSumOfAgriIncome = 0.0;
                    foreach (ClientInputData inputData in subLstClInputData)
                    {

                        if (inputData.IncomeSubCategoryId == 1)
                        {
                            dSumOfSalaryIncome += inputData.Receipts;
                            // sumOfReceipts += inputData.Receipts;
                            //sLblName = "SALARY INCOME(" + inputData.ClientDataName + ")";
                            // opReceipt.Add(sLblName, inputData.Receipts);
                        }
                        else if (inputData.IncomeSubCategoryId == 2)
                        {
                            dSumOfRentalIncome += inputData.Receipts;

                        }
                        else if (inputData.IncomeSubCategoryId == 3)
                        {
                            isBusinessIncomeFound = true;
                            dSumOfBusinessProfIncome += inputData.Receipts;
                        }
                        else if (inputData.IncomeSubCategoryId == 4)
                        {
                            dSumOfOtherIncome += inputData.Receipts;
                        }
                        else if (inputData.IncomeSubCategoryId == 5)
                        {
                            dSumOfAgriIncome += inputData.Receipts;
                        }
                    }
                    if (isBusinessIncomeFound)
                    {
                        _dBusinessIncome = dSumOfBusinessProfIncome;
                    }
                    sumOfReceipts += dSumOfSalaryIncome;
                    opReceipt.Add("SALARY INCOME", dSumOfSalaryIncome);
                    sumOfReceipts += dSumOfRentalIncome;
                    opReceipt.Add("RENTAL INCOME", dSumOfRentalIncome);
                    sumOfReceipts += dSumOfOtherIncome;
                    opReceipt.Add("OTHER INCOME", dSumOfOtherIncome);
                    sumOfReceipts += dSumOfAgriIncome;
                    opReceipt.Add("AGRICULTURE INCOME", dSumOfAgriIncome);
                }
                subLstClInputData = findCategoryId(9, lstClientInputData);
                //if(clInputData != null && clInputData.OpeningBalance>0)
                if (subLstClInputData.Count > 0)
                {
                    double dSumGiftReceived = 0.0;
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        dSumGiftReceived += inputData.Receipts;

                    }
                    sLblName = "GIFT RECEIVED";
                    opReceipt.Add(sLblName, dSumGiftReceived);
                    sumOfReceipts += dSumGiftReceived;
                }
                subLstClInputData = findCategoryId(8, lstClientInputData);
                if (subLstClInputData.Count > 0.0)
                {
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        if (inputData.ExpenditureSubCategoryId == 3)
                        {
                            isBusinessExpenditureFound = true;
                            dSumOfBusinessProfExpenditure += inputData.Payments;
                        }
                    }
                    if (isBusinessExpenditureFound)
                    {
                        _dBusinessExpenditure = dSumOfBusinessProfExpenditure;
                    }
                }
                if (isBusinessIncomeFound)
                {
                    if (isBusinessExpenditureFound)
                    {
                        if (dSumOfBusinessProfIncome > dSumOfBusinessProfExpenditure)
                        {
                            dBusProfIncomeExp = dSumOfBusinessProfIncome - dSumOfBusinessProfExpenditure;
                            sumOfReceipts += dBusProfIncomeExp;
                            opReceipt.Add("BUSINESS/PROFESSION INCOME", dBusProfIncomeExp);
                        }
                        else
                        {
                            opReceipt.Add("BUSINESS/PROFESSION INCOME", 0.0);
                        }
                    }
                }
                _dTotalReceipt = sumOfReceipts;
                opReceipt.Add("TOTAL", sumOfReceipts);
                TblReceipt = opReceipt;
                return "1";
            }
            return "no data";
        }
        public string computeReceiptAndPayment(ClientInfo clientInfo)
        {
            //Dictionary<string, double> computeDataSet = new Dictionary<string, double>();
            Hashtable payment_receipt_op = new Hashtable();
            try
            {
                if (clientInfo != null)
                {
                    //payment_receipt_op.Add("RECEIPT", computeReceipt(clientInfo._lstInputData));
                    //payment_receipt_op.Add("PAYMENT", computePayments(clientInfo._lstInputData));
                    if (computeReceipt() == "1" && computePayments() == "1")
                    {
                        return "1";
                    }
                    else
                    {
                        _lastError = "ComputeReceipt or ComputePayments failed";
                        return "0";
                    }
                }
            }
            catch (Exception e)
            {
                _lastError = e.Message;
                return e.Message;
            }
            return "0";
        }
        public string computeIncome()
        {
            List<ClientInputData> subLstClInputData;
            Hashtable opIncome = new Hashtable();
            double dSumOfIncome = 0.0;
            double dSumOfExpenditure;
            if (_dBusinessExpenditure != 0)
            {
                dSumOfExpenditure = _dBusinessExpenditure;
            }
            else
            {
                dSumOfExpenditure = getSumOfBusinessExpenditure();
            }
            double dExcessExpenditure = 0.0;
            if (_objClientInfo._lstInputData.Count != 0)
            {
                subLstClInputData = findCategoryId(7, _objClientInfo._lstInputData);
                if (subLstClInputData.Count > 0)
                {
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        dSumOfIncome += inputData.Receipts;
                        opIncome.Add(inputData.ClientDataName, inputData.Receipts);
                    }
                }
                if (dSumOfExpenditure > 0)
                {
                    if (dSumOfIncome > 0)
                    {
                        if (dSumOfExpenditure > dSumOfIncome)
                        {
                            dExcessExpenditure = dSumOfExpenditure - dSumOfIncome;
                            dSumOfIncome += dExcessExpenditure;
                            opIncome.Add("EXCESS OF EXPENDITURE OVER INCOME", dExcessExpenditure);
                        }
                    }
                }
                opIncome.Add("TOTAL", dSumOfIncome);
                TblIncome = opIncome;
                return "1";
            }
            _lastError = "Client input Data list is corrupted";
            return "0";
        }
        public string computeExpenditure()
        {
            List<ClientInputData> subLstClInputData;
            Hashtable opExpense = new Hashtable();
            double dSumOfExpense = 0.0;
            double dSumOfIncome = getSumOfBusinessIncome();
            double dExcessIncome = 0.0;
            if (_objClientInfo._lstInputData.Count != 0)
            {
                subLstClInputData = findCategoryId(8, _objClientInfo._lstInputData);
                if (subLstClInputData.Count > 0)
                {
                    foreach (ClientInputData inputData in subLstClInputData)
                    {
                        dSumOfExpense += inputData.Receipts;
                        opExpense.Add(inputData.ClientDataName, inputData.Receipts);
                    }
                }
                if (dSumOfIncome > 0)
                {
                    if (dSumOfExpense > 0)
                    {
                        if (dSumOfIncome > dSumOfExpense)
                        {
                            dExcessIncome = dSumOfIncome - dSumOfExpense;
                            dSumOfExpense += dExcessIncome;
                            opExpense.Add("EXCESS OF INCOME OVER EXPENDITURE", dExcessIncome);
                        }
                    }
                }
                opExpense.Add("TOTAL", dSumOfExpense);
            }
            return null;
        }
        public double getSumOfBusinessIncome()
        {
            List<ClientInputData> subLstClientInputData;
            subLstClientInputData = findCategoryId(7, _objClientInfo._lstInputData);
            double sumOfIncome = 0.0;
            if (subLstClientInputData != null || subLstClientInputData.Count > 0)
            {
                foreach (ClientInputData inputData in subLstClientInputData)
                {
                    sumOfIncome = inputData.Receipts;
                }
                return sumOfIncome;
            }
            return 0;
        }
        public double getSumOfBusinessExpenditure()
        {
            List<ClientInputData> subLstClientInputData;
            subLstClientInputData = findCategoryId(8, _objClientInfo._lstInputData);
            double sumOfExpenditure = 0.0;
            if (subLstClientInputData != null || subLstClientInputData.Count > 0)
            {
                foreach (ClientInputData inputData in subLstClientInputData)
                {
                    sumOfExpenditure = inputData.Payments;
                }
                return sumOfExpenditure;
            }
            return 0;
        }
        public string computeIncomeAndExpenditure()
        {
            //Dictionary<string, double> computeDataSet = new Dictionary<string, double>();
            Hashtable payment_receipt_op = new Hashtable();
            try
            {
                if (_objClientInfo != null)
                {
                    if (computeIncome() == "1" && computeExpenditure() == "1")
                    {
                        return "1";
                    }
                    _lastError = "computeIncome or computeExpense is failed";
                    return "0";
                }
            }
            catch (Exception execption)
            {
                if (execption.InnerException is NullReferenceException)
                {
                    //computeDataSet["NullException"] = 0;
                }
            }
            return "Client input data is corrupted";

        }
        public string computeAddCapital()
        {
            double dAddSubTotal = 0.0;
            double dAddTotal = 0.0;
            double dSumOfOpeningBalance = 0.0;
            string strReceiptError = "1";
            string strPaymentError = "1";
            double dTempSum = 0.0;
            _tblAddCapital = new Hashtable();
            List<ClientInputData> subLstClientInputData;
            if (_objClientInfo._lstInputData != null && _objClientInfo._lstInputData.Count > 0)
            {
                subLstClientInputData = findCategoryId(9, _objClientInfo._lstInputData);
                if (subLstClientInputData != null && subLstClientInputData.Count > 0)
                {
                    foreach (ClientInputData inputData in subLstClientInputData)
                    {
                        dSumOfOpeningBalance += inputData.OpeningBalance;
                    }
                    _tblAddCapital.Add("OPENING BALANCE", dSumOfOpeningBalance);
                    //dAddSubTotal += dSumOfOpeningBalance;
                }
                if (_isReceiptComputeDone == false)
                {
                    strReceiptError = computeReceipt();
                }
                if (_isPaymentComputeDone == false)
                {
                    strPaymentError = computePayments();
                }
                if (strReceiptError != "1" || strPaymentError != "1")
                {
                    return strPaymentError + strReceiptError;
                }
                if (_tblPayment.Count > 0 && _tblReceipt.Count > 0)
                {
                    if (_tblReceipt.ContainsKey("SALARY INCOME"))
                    {
                        if (_tblPayment.ContainsKey("SALARY EXPENDITURE"))
                        {
                            dTempSum = ((double)_tblReceipt["SALARY INCOME"]) - ((double)_tblPayment["SALARY EXPENDITURE"]);
                        }
                        else
                        {
                            dTempSum = (double)_tblReceipt["SALARY INCOME"];
                        }
                        _tblAddCapital["SALARY INCOME"] = dTempSum;
                        dAddSubTotal += dTempSum;
                        dTempSum = 0.0;
                    }
                    if (_tblReceipt.ContainsKey("RENTAL INCOME"))
                    {
                        if (_tblPayment.ContainsKey("RENTAL EXPENDITURE"))
                        {
                            dTempSum = ((double)_tblReceipt["RENTAL INCOME"]) - ((double)_tblPayment["RENTAL EXPENDITURE"]);
                        }
                        else
                        {
                            dTempSum = (double)_tblReceipt["RENTAL INCOME"];
                        }
                        _tblAddCapital["RENTAL INCOME"] = dTempSum;
                        dAddSubTotal += dTempSum;
                        dTempSum = 0.0;
                    }
                    if (_tblReceipt.ContainsKey("OTHER INCOME"))
                    {
                        if (_tblPayment.ContainsKey("OTHER EXPENDITURE"))
                        {
                            dTempSum = ((double)_tblReceipt["OTHER INCOME"]) - ((double)_tblPayment["OTHER EXPENDITURE"]);
                        }
                        else
                        {
                            dTempSum = (double)_tblReceipt["OTHER INCOME"];
                        }
                        _tblAddCapital["OTHER INCOME"] = dTempSum;
                        dAddSubTotal += dTempSum;
                        dTempSum = 0.0;
                    }
                    if (_tblReceipt.ContainsKey("AGRICULTURE INCOME"))
                    {
                        if (_tblPayment.ContainsKey("AGRICULTURE EXPENDITURE"))
                        {
                            dTempSum = ((double)_tblReceipt["AGRICULTURE INCOME"]) - ((double)_tblPayment["AGRICULTURE EXPENDITURE"]);
                        }
                        else
                        {
                            dTempSum = (double)_tblReceipt["AGRICULTURE INCOME"];
                        }
                        _tblAddCapital["AGRICULTURE INCOME"] = dTempSum;
                        dAddSubTotal += dTempSum;
                        dTempSum = 0.0;
                    }
                    if (_tblReceipt.ContainsKey("BANK SB INTEREST"))
                    {
                        dTempSum = (double)_tblReceipt["BANK SB INTEREST"];
                        _tblAddCapital.Add("BANK SB INTEREST", dTempSum);
                        dAddSubTotal += dTempSum;
                        dTempSum = 0.0;
                    }
                    if (_tblReceipt.ContainsKey("DEPOSIT INTEREST INCOME"))
                    {
                        dTempSum = (double)_tblReceipt["DEPOSIT INTEREST INCOME"];
                        _tblAddCapital.Add("DEPOSIT INTEREST INCOME", dTempSum);
                        dAddSubTotal += dTempSum;
                        dTempSum = 0.0;
                    }
                    if (_tblReceipt.ContainsKey("GIFT RECEIVED"))
                    {
                        dTempSum = (double)_tblReceipt["GIFT RECEIVED"];
                        _tblAddCapital.Add("GIFT RECEIVED", dTempSum);
                        dAddSubTotal += dTempSum;
                        dTempSum = 0.0;
                    }
                }
                else
                {
                    _lastError = "No payment and receipt is found";
                    return "0";
                }
                List<ClientInputData> lstDeposit = findCategoryId(4, _objClientInfo._lstInputData);
                if (lstDeposit.Count > 0)
                {
                    double dDepIntAccured = 0.0;
                    foreach (ClientInputData inputData in lstDeposit)
                    {
                        dDepIntAccured += inputData.InterestAccrued;
                    }
                    dTempSum = dDepIntAccured;
                    _tblAddCapital.Add("BANK INTEREST ACCRUED", dTempSum);
                    dAddSubTotal += dTempSum;
                    dTempSum = 0.0;
                }
                List<ClientInputData> lstIncome = findCategoryId(7, _objClientInfo._lstInputData);
                List<ClientInputData> lstExpenditure = findCategoryId(8, _objClientInfo._lstInputData);
                if (lstIncome.Count > 0 && lstExpenditure.Count > 0)
                {
                    double dBusIncome = 0.0;
                    double dBusExpend = 0.0;
                    foreach (ClientInputData inputData in lstIncome)
                    {
                        if (inputData.IncomeSubCategoryId == 3)
                        {
                            dBusIncome += inputData.Receipts;
                        }
                    }
                    foreach (ClientInputData inputData in lstIncome)
                    {
                        if (inputData.ExpenditureSubCategoryId == 3)
                        {
                            dBusExpend += inputData.Payments;
                        }
                    }
                    if (dBusIncome > 0)
                    {
                        if (dBusExpend > 0)
                        {
                            dTempSum = dBusIncome - dBusExpend;
                        }
                        else
                        {
                            dTempSum = dBusIncome;
                        }
                        _tblAddCapital.Add("BUSINESS INCOME", dTempSum);
                        dAddSubTotal += dTempSum;
                        dTempSum = 0.0;
                    }
                }
                /*else
                {
                    return "Income or Expenditure is empty";
                }*/
                List<ClientInputData> lstFirm = findCategoryId(3, _objClientInfo._lstInputData);
                if (lstFirm.Count > 0)
                {
                    double dInterestOnFirm = 0.0;
                    double dRemunFromFirm = 0.0;
                    double dShareOfProfit = 0.0;

                    foreach (ClientInputData inputData in lstFirm)
                    {
                        dInterestOnFirm += inputData.InterestOnCapitalAmount;
                        dRemunFromFirm += inputData.Remuneration;
                        if (inputData.ShareOfProfitOrLoss > 0)
                        {
                            dShareOfProfit += inputData.ShareOfProfitOrLoss;
                        }
                    }
                    dTempSum = dInterestOnFirm;
                    _tblAddCapital.Add("INTEREST ON CAPITAL FROM FIRM", dTempSum);
                    dAddSubTotal += dTempSum;
                    dTempSum = dRemunFromFirm;
                    _tblAddCapital.Add("REMUNERATION FROM FIRM", dTempSum);
                    dAddSubTotal += dTempSum;
                    dTempSum = dRemunFromFirm;
                    _tblAddCapital.Add("SHARE OF PROFITS FROM FIRM", dTempSum);
                    dAddSubTotal += dTempSum;
                    dTempSum = 0.0;
                }
                List<ClientInputData> lstFixedAssets = findCategoryId(2, _objClientInfo._lstInputData);
                if (lstFixedAssets.Count > 0)
                {
                    foreach (ClientInputData inputData in lstFixedAssets)
                    {
                        if (inputData.Receipts > inputData.OpeningBalance)
                        {
                            dTempSum += inputData.Receipts - inputData.OpeningBalance;
                            _tblAddCapital.Add("PROFIT ON SALE OF FIXED ASSETS(" + inputData.ClientDataName + ")", dTempSum);
                            dAddSubTotal += dTempSum;
                            dTempSum = 0.0;
                        }
                    }
                }
                _tblAddCapital.Add("SUBTOTAL", dAddSubTotal);
                dAddTotal = dSumOfOpeningBalance + dAddTotal;
                _tblAddCapital.Add("TOTAL", dAddTotal);
                _lastError = "SUCCESS";
                _isCapitalAddComputeDone = true;
                return "1";
            }
            _lastError = "Client input data is corrupted";
            return "0";

        }
        public string computeLessCapital()
        {
            double dLessSubTotal = 0.0;
            double dSumOfGiftPaid = 0.0;
            double dSumOfInvestFirm = 0.0;
            double dClosingBalance = 0.0;
            string ret = "";
            bool isAddTotalAvail = false;
            double dAddTotal = 0.0;
            List<ClientInputData> subLstExpenditure;
            if (_isCapitalAddComputeDone == false)
            {
                ret = computeAddCapital();
                if (ret == "1")
                {
                    isAddTotalAvail = true;
                    dAddTotal = (double)_tblAddCapital["TOTAL"];
                }
            }
            subLstExpenditure = findCategoryId(8, _objClientInfo._lstInputData);
            if (subLstExpenditure.Count > 0)
            {
                foreach (ClientInputData inputData in subLstExpenditure)
                {
                    if (inputData.ExpenditureSubCategoryId == 6)
                    {
                        dLessSubTotal += inputData.Payments;
                        _tblLessCapital.Add(inputData.ClientDataName, inputData.Payments);
                    }
                }
            }
            List<ClientInputData> subListCapitalPayment = findCategoryId(9, _objClientInfo._lstInputData);
            if (subListCapitalPayment.Count > 0)
            {
                foreach (ClientInputData inputData in subListCapitalPayment)
                {
                    dSumOfGiftPaid += inputData.Payments;
                }
                if (dSumOfGiftPaid > 0.0)
                {
                    dLessSubTotal += dSumOfGiftPaid;
                    _tblLessCapital.Add("GIFT PAID", dSumOfGiftPaid);
                }
            }
            List<ClientInputData> subInvestFirm = findCategoryId(3, _objClientInfo._lstInputData);
            if (subInvestFirm.Count > 0)
            {
                foreach (ClientInputData inputData in subInvestFirm)
                {
                    dSumOfInvestFirm += inputData.ShareOfProfitOrLoss;
                }
                if (dSumOfInvestFirm > 0.0)
                {
                    dLessSubTotal += dSumOfGiftPaid;
                    _tblLessCapital.Add("SHARE OF LOSS FROM FIRM", dSumOfInvestFirm);
                }
            }
            List<ClientInputData> lstFixedAssets = findCategoryId(2, _objClientInfo._lstInputData);
            if (lstFixedAssets.Count > 0)
            {
                foreach (ClientInputData inputData in lstFixedAssets)
                {
                    if (inputData.Receipts < inputData.OpeningBalance)
                    {
                        dLessSubTotal += inputData.OpeningBalance - inputData.Receipts;
                        _tblAddCapital.Add("LOSS ON SALE OF FIXED ASSETS(" + inputData.ClientDataName + ")", dLessSubTotal);
                    }
                }
            }
            if (isAddTotalAvail)
            {
                dClosingBalance = dAddTotal - dLessSubTotal;
                _lastError = "SUCCES";
                _tblLessCapital.Add("CLOSING BALANCE", dClosingBalance);
                return "1";
            }
            else
            {
                _lastError = "Capital Add is not found.";
            }
            return "0";
        }
        public string computationOfCapital()
        {
            // Hashtable opCapital = new Hashtable();
            if (_tblAddCapital.Count > 0 && _tblLessCapital.Count > 0)
            {
                _lastError = "SUCCESS";
                return "1";
            }
            else
            {
                return "Capital Add or Less is not computed or in error!";
            }

        }
    }
    class ClientInfo
    {
        string _strPanNumber;
        public String PanNumber { get { return _strPanNumber; } set { _strPanNumber = PanNumber; } }
        string _strName;
        public String Name { get { return _strName; } set { _strName = Name; } }
        string _strRelationName;
        public String RelatioName { get { return _strRelationName; } set { _strRelationName = RelatioName; } }
        public List<ClientInputData> _lstInputData;
        public ClientInfo()
        {
            _lstInputData.Clear();
        }

    }
    class ClientInputData
    {
        public int amount1;
        string _strClientDataName; //Input Description
        public string ClientDataName { get { return _strClientDataName; } set { _strClientDataName = ClientDataName; } }
        int _iClientDataCategory; //Category Id
        public int ClientDataCategory { get { return _iClientDataCategory; } set { _iClientDataCategory = ClientDataCategory; } }
        int _iFinancialYearId; //FinancialYear Id
        public int FinancialYearId { get { return _iFinancialYearId; } set { _iFinancialYearId = FinancialYearId; } }

        double _dOpeningBalance; //Opening Balance
        public double OpeningBalance { get { return _dOpeningBalance; } set { _dOpeningBalance = OpeningBalance; } }
        double _dReceipts;
        public double Receipts { get { return _dReceipts; } set { _dReceipts = Receipts; } }
        double _dPercentageOfPortionSold;
        public double PercentageOfPortionSold { get { return _dPercentageOfPortionSold; } set { _dPercentageOfPortionSold = PercentageOfPortionSold; } }
        double _dPayments;
        public double Payments { get { return _dPayments; } set { _dPayments = Payments; } }
        double _dInterestOnCapitalAmount;
        public double InterestOnCapitalAmount { get { return _dInterestOnCapitalAmount; } set { _dInterestOnCapitalAmount = InterestOnCapitalAmount; } }
        double _dRemuneration;
        public double Remuneration { get { return _dRemuneration; } set { _dRemuneration = Remuneration; } }
        double _dShareOfProfitOrLoss;
        public double ShareOfProfitOrLoss { get { return _dShareOfProfitOrLoss; } set { _dShareOfProfitOrLoss = ShareOfProfitOrLoss; } }
        double _dInterestAccrued;
        public double InterestAccrued { get { return _dInterestAccrued; } set { _dInterestAccrued = InterestAccrued; } }
        double _dInterestReceived;
        public double InterestReceived { get { return _dInterestReceived; } set { _dInterestReceived = InterestReceived; } }
        double _dClosingBalance;
        public double ClosingBalance { get { return _dClosingBalance; } set { _dClosingBalance = ClosingBalance; } }
        int _iIncomeSubCategoryId;
        public int IncomeSubCategoryId { get { return _iIncomeSubCategoryId; } set { _iIncomeSubCategoryId = IncomeSubCategoryId; } }
        int _iExpenditureSubCategoryId;
        public int ExpenditureSubCategoryId { get { return _iExpenditureSubCategoryId; } set { _iExpenditureSubCategoryId = ExpenditureSubCategoryId; } }


        //Liabilities
        //double _dLiabOpeningBalance; //1.1.1
        //public double LiabOpeningBalance { get { return _dLiabOpeningBalance; } set { _dLiabOpeningBalance = LiabOpeningBalance; } }
        //double _dLiabRecvdAmt; //1.2.1.1
        //public double LiabRecvdAmt { get { return _dLiabRecvdAmt; } set { _dLiabRecvdAmt = LiabRecvdAmt; } }
        //double _dLiabPaidAmt;//1.2.2.1
        //public double LiabPaidAmt { get { return _dLiabRecvdAmt; } set { _dLiabPaidAmt = LiabPaidAmt; } }

        //Fixed Assets
        //double _dFAOpeningBalance; //2.1.1
        //public double FAOpeningBalance { get { return _dFAOpeningBalance; } set { _dFAOpeningBalance = FAOpeningBalance; } }
        //bool _isFullySold;
        //public bool isFullySold { get {return _isFullySold;} set { _isFullySold = isFullySold;}}
        //double _dsFAFullySoldRcvdAmt; //2.2.1.1.1.1
        //public double FAFullySoldRcvdAmt { get { return _dsFAFullySoldRcvdAmt; } set { _dsFAFullySoldRcvdAmt = FAFullySoldRcvdAmt; } }
        //float _fFAPerctageSold; //2.2.1.1.2.1
        //public float FAPercentageSold { get { return _fFAPerctageSold; } set { _fFAPerctageSold = FAPercentageSold; } }
        //double _dFAPartSoldRcvdAmt;//2.2.1.1.2.1.1
        //public double FAPartSoldRcvdAmt { get { return _dFAPartSoldRcvdAmt; } set { _dFAPartSoldRcvdAmt = FAPartSoldRcvdAmt; } }
        //double _dFAPaidAmt;//2.2.2.1
        //public double FAPaidAmt { get { return _dFAPaidAmt; } set { _dFAPaidAmt = FAPaidAmt; } }

        //Firm Investment
        //double _dFIOpeningBalance; //3.1.1
        //public double FIOpeningBalance { get { return _dFIOpeningBalance; } set { _dFIOpeningBalance = FIOpeningBalance; } }
        //double _dFIAdditonMadeAmt; //3.2.1
        //public double FIAdditonMadeAmt { get { return _dFIAdditonMadeAmt; } set { _dFIAdditonMadeAmt = FIAdditonMadeAmt; } }
        //double _dFIIntOnCapAmt; //3.2.2
        //public double FIIntOnCapAmt { get { return _dFIIntOnCapAmt; } set { _dFIIntOnCapAmt = FIIntOnCapAmt; } }
        //double _dFIRenumAmt; //3.2.3
        //public double FIRenumAmt { get { return _dFIRenumAmt; } set { _dFIRenumAmt = FIRenumAmt; } }
        //double _dFIShareProfLossAmt; //3.2.4
        //public double FIShareProfLossAmt { get { return _dFIShareProfLossAmt; } set { _dFIShareProfLossAmt = FIShareProfLossAmt; } }
        //double _dFIDrawMadeAmt; //3.2.5
        //public double FIDrawMadeAmt { get { return _dFIDrawMadeAmt; } set { _dFIDrawMadeAmt = FIDrawMadeAmt; } }

        //Deposit
        //double _dDepositOpeningBalance; //4.1.1
        //public double DepositOpeningBalance { get { return _dDepositOpeningBalance; } set { _dDepositOpeningBalance = DepositOpeningBalance; } }
        //double _dDepositNewPaidAmt; //4.2.4
        //public double DepositNewPaidAmt { get { return _dDepositNewPaidAmt; } set { _dDepositNewPaidAmt = DepositNewPaidAmt; } }
        //double _dDepositIntAccAmt; //4.2.1.1
        //public double DepositIntAccAmt { get { return _dDepositIntAccAmt; } set { _dDepositIntAccAmt = DepositIntAccAmt; } }
        //double _dDepositIntRcvdAmt; //4.2.2
        //public double DepositIntRcvdAmt { get { return _dDepositIntRcvdAmt; } set { _dDepositIntRcvdAmt = DepositIntRcvdAmt; } }
        //double _dDepositClosedRcvdAmt; //4.2.3
        //public double DepositClosedRcvdAmt { get { return _dDepositClosedRcvdAmt; } set { _dDepositClosedRcvdAmt = DepositClosedRcvdAmt; } }


        //BankAcount
        //double _dBankOpeningBalance; //5.1.1
        //public double BankOpeningBalance { get { return _dBankOpeningBalance; } set { _dBankOpeningBalance = BankOpeningBalance; } }
        //double _dBankClosingBalance; //5.2.1
        //public double BankClosingBalance { get { return _dBankClosingBalance; } set { _dBankClosingBalance = BankClosingBalance; } }
        //double _dBankSavgInterest; //5.3.1
        //public double BankSavgInterest { get { return _dBankSavgInterest; } set { _dBankSavgInterest = BankSavgInterest; } }

        //OtherAsset
        //double _dOAOpeningBalance; //6.1.1
        //public double OAOpeningBalance { get { return _dOAOpeningBalance; } set { _dOAOpeningBalance = OAOpeningBalance; } }
        //double _dOARecvdAmt; //6.2.1.1
        //public double OARecvdAmt { get { return _dOARecvdAmt; } set { _dOARecvdAmt = OARecvdAmt; } }
        //double _dOAPaidAmt;//6.2.2.1
        //public double OAPaidAmt { get { return _dOARecvdAmt; } set { _dOAPaidAmt = OAPaidAmt; } }

        //Income
        //double _dSalaryIncome; //7.1.1
        //public double SalaryIncome { get { return _dSalaryIncome; } set { _dSalaryIncome = SalaryIncome; } }
        //double _dRentalIncome; //7.2.1
        //public double RentalIncome { get { return _dRentalIncome; } set { _dRentalIncome = RentalIncome; } }
        //double _dBusinessIncome; //7.3.1
        //public double BusinessIncome { get { return _dBusinessIncome; } set { _dBusinessIncome = BusinessIncome; } }
        //double _dOtherIncome; //7.4.1
        //public double OtherIncome { get { return _dOtherIncome; } set { _dOtherIncome = OtherIncome; } }
        //double _dAgriIncome; //7.5.1
        //public double AgriIncome { get { return _dAgriIncome; } set { _dAgriIncome = AgriIncome; } }

        //Expenditure
        //double _dSalaryExpenditure; //8.1.1
        //public double SalaryExpenditure { get { return _dSalaryExpenditure; } set { _dSalaryExpenditure = SalaryExpenditure; } }
        //double _dRentalExpenditure; //8.2.1
        //public double RentalExpenditure { get { return _dRentalExpenditure; } set { _dRentalExpenditure = RentalExpenditure; } }
        //double _dBusinessExpenditure; //8.3.1
        //public double BusinessExpenditure { get { return _dBusinessExpenditure; } set { _dBusinessExpenditure = BusinessExpenditure; } }
        //double _dOtherExpenditure; //8.4.1
        //public double OtherExpenditure { get { return _dOtherExpenditure; } set { _dOtherExpenditure = OtherExpenditure; } }
        //double _dAgriExpenditure; //8.5.1
        //public double AgriExpenditure { get { return _dAgriExpenditure; } set { _dAgriExpenditure = AgriExpenditure; } }
        //double _dPersonalExpenditure; //8.6.1
        //public double PersonalExpenditure { get { return _dPersonalExpenditure; } set { _dPersonalExpenditure = PersonalExpenditure; } }

        //Capital
        /*double _dCapitalOpeningBalance; //9.1.1
        public double CapitalOpeningBalance { get { return _dCapitalOpeningBalance; } set { _dCapitalOpeningBalance = CapitalOpeningBalance; } }
        double _dCapitalRecvdAmt; //9.2.1
        public double CapitalRecvdAmt { get { return _dCapitalRecvdAmt; } set { _dCapitalRecvdAmt = CapitalRecvdAmt; } }
        double _dCapitalPaidAmt;//9.2.2
        public double CapitalPaidAmt { get { return _dCapitalRecvdAmt; } set { _dCapitalPaidAmt = CapitalPaidAmt; } }*/

        public ClientInputData(int data1)
        {
            amount1 = data1;
        }

    }    
}
