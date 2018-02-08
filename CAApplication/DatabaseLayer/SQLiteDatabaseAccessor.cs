using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;
using Common;
using System.Windows.Forms;
namespace DatabaseLayer
{
    public class SQLiteDatabaseAccessor
    {
        private SQLiteConnection m_dbConnection;

        public SQLiteDatabaseAccessor()
        {

            string executetablePath = Path.Combine(Directory.GetParent(Application.ExecutablePath).FullName, Constants.SQLiteDatabase);
            if (!File.Exists(executetablePath))
            {
                CreateSQLiteDatabase();
                CreateSQLiteTables();
            }
        }


        /// <summary>
        /// Registers new auditor user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool RegisterUser(string userId, string password)
        {
            // Check if the same userid is already there in database. If so, return false. Otherwise add new user entry in database
            CreateSQLiteDBConnection();
            bool isRegistrationSuccess = false;
            string sqliteQuery = "select * from tblAuditors where UserId = '" + userId + "'";
            SQLiteCommand command = new SQLiteCommand(sqliteQuery, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                // Already user is there
                return isRegistrationSuccess;
            }
            else
            {
                sqliteQuery = "insert into tblAuditors (UserId, Password) values ('" + userId + "', '" + password + "')";
                command = new SQLiteCommand(sqliteQuery, m_dbConnection);
                command.ExecuteNonQuery();
                isRegistrationSuccess = true;

            }

            CloseSQLiteDBConnection();
            return isRegistrationSuccess;

        }

        /// <summary>
        /// Authenticates the the user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsLoginSuccess(string userId, string password)
        {
            // Check if the userId and password combination is availabl in database. If so return true. otherwise return false.
            CreateSQLiteDBConnection();
            bool isLoginSucess = false;
            string sqliteQuery = "select * from tblAuditors where UserId = '" + userId + "' and Password = '" + password + "'";
            SQLiteCommand command = new SQLiteCommand(sqliteQuery, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isLoginSucess = true;
            }

            CloseSQLiteDBConnection();
            return isLoginSucess;


        }

        /// <summary>
        /// Adds new client to the database
        /// </summary>
        /// <param name="clientInfo"></param>
        /// <returns></returns>
        public bool AddClient(ClientInfo clientInfo)
        {
            // check if the client is already there. If so, return false. Other wise add client to the table tblClientInfo and return true
            CreateSQLiteDBConnection();

            bool isAddClient = false;
            bool isClientAlreadyExists = false;
            string sqliteQuery = "select * from tblClientInfo where PANNumber = '" + clientInfo.PANNumber + "'";
            SQLiteCommand command = new SQLiteCommand(sqliteQuery, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            isClientAlreadyExists = reader.Read();
            CloseSQLiteDBConnection();
            if (isClientAlreadyExists)
            {
                // Client is already there. Do not add client
                isAddClient = false;
            }
            else
            {
                // Client is not there. Add client
                isAddClient = true;
                CreateSQLiteDBConnection();
                sqliteQuery = "insert into tblClientInfo values ("
                    + "'" + clientInfo.PANNumber + "', "
                    + "'" + clientInfo.Name + "', "
                    + "'" + clientInfo.FatherOrHusbandName + "', "
                    + "'" + clientInfo.MobileNumber + "', "
                    + "'" + clientInfo.EmailId + "', "
                    + "'" + clientInfo.Address + "', "
                    + "'" + clientInfo.DateOfBirth + "', "
                    + clientInfo.AuditorId
                    + ")";

                command = new SQLiteCommand(sqliteQuery, m_dbConnection);
                command.ExecuteNonQuery();
                CloseSQLiteDBConnection();
            }

            
            return isAddClient;
        }

        /// <summary>
        /// Gets the list of available clients for particular auditor
        /// </summary>
        /// <param name="auditorId"></param>
        /// <returns></returns>
        public List<ClientInfo> GetClients(int auditorId)
        {
            List<ClientInfo> clients = new List<ClientInfo>();
            CreateSQLiteDBConnection();

            string sqliteQuery = "select PANNumber, Name, FatherOrHusbandName, MobileNumber, EmailId, Address, DateOfBirth from tblClientInfo where AuditorId = " + auditorId;
            SQLiteCommand command = new SQLiteCommand(sqliteQuery, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ClientInfo client = new ClientInfo();
                client.PANNumber = reader.GetString(0);
                client.Name = reader.GetString(1);
                client.FatherOrHusbandName = reader.GetString(2);
                client.MobileNumber = reader.GetString(3);
                client.EmailId = reader.GetString(4);
                client.Address = reader.GetString(5);
                client.DateOfBirth = reader.GetString(6);
                client.AuditorId = auditorId;

                clients.Add(client);
            }

            CloseSQLiteDBConnection();
            return clients;
        }

        /// <summary>
        /// Gets the list of client input data for particular client
        /// </summary>
        /// <param name="panNumber"></param>
        /// <returns></returns>
        public List<ClientInputData> GetClientInputDatas(string panNumber)
        {
            List<ClientInputData> clientInputDatas = new List<ClientInputData>();

            CreateSQLiteDBConnection();

            string sqliteQuery = "select * from tblClientInputData where PANNumber = '" + panNumber + "'";

            SQLiteCommand command = new SQLiteCommand(sqliteQuery, m_dbConnection);

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ClientInputData clientInputData = new ClientInputData();
                clientInputData.InputDesc = reader.GetString(0);
                clientInputData.CategoryId = reader.GetInt32(1);
                clientInputData.FinancialYearId = reader.GetInt32(2);
                clientInputData.OpeningBalance = reader.GetDouble(3);
                clientInputData.Receipts = reader.GetDouble(4);
                clientInputData.PercentageOfPortionSold = reader.GetDouble(5);
                clientInputData.Payments = reader.GetDouble(6);
                clientInputData.InterestOnCapitalAmount = reader.GetDouble(7);
                clientInputData.Remuneration = reader.GetDouble(8);
                clientInputData.ShareOfProfitOrLoss = reader.GetDouble(9);
                clientInputData.InterestAccrued = reader.GetDouble(10);
                clientInputData.InterestReceived = reader.GetDouble(11);
                clientInputData.ClosingBalance = reader.GetDouble(12);
                clientInputData.IncomeSubCategoryId = reader.GetInt32(13);
                clientInputData.ExpenditureSubCategoryId = reader.GetInt32(14);

                clientInputDatas.Add(clientInputData);

            }

            CloseSQLiteDBConnection();

            return clientInputDatas;
        }

        /// <summary>
        /// Saves client input data for particular client
        /// </summary>
        /// <param name="panNumber"></param>
        /// <param name="clientInputDatas"></param>
        public void SaveClientInputData(string panNumber, List<ClientInputData> clientInputDatas)
        {

            CreateSQLiteDBConnection();
            string sqliteQuery = "delete from tblClientInputData where PANNumber = '" + panNumber + "'";
            SQLiteCommand sqliteCommand = new SQLiteCommand(sqliteQuery, m_dbConnection);
            sqliteCommand.ExecuteNonQuery();

            foreach (ClientInputData clientInputData in clientInputDatas)
            {
                sqliteQuery = "insert into tblClientInputData values ("
                    + "'" + clientInputData.InputDesc + "', "
                    + clientInputData.CategoryId + ", "
                    + clientInputData.FinancialYearId + ", "
                    + clientInputData.OpeningBalance + ", "
                    + clientInputData.Receipts + ", "
                    + clientInputData.PercentageOfPortionSold + ", "
                    + clientInputData.Payments + ", "
                    + clientInputData.InterestOnCapitalAmount + ", "
                    + clientInputData.Remuneration + ", "
                    + clientInputData.ShareOfProfitOrLoss + ", "
                    + clientInputData.InterestAccrued + ", "
                    + clientInputData.InterestReceived + ", "
                    + clientInputData.ClosingBalance + ", "
                    + clientInputData.IncomeSubCategoryId + ", "
                    + clientInputData.ExpenditureSubCategoryId + ", "
                    + "'" + panNumber + "'"
                    + ")";

                sqliteCommand = new SQLiteCommand(sqliteQuery, m_dbConnection);
                sqliteCommand.ExecuteNonQuery();
            }
            CloseSQLiteDBConnection();
        }

        public Dictionary<int, string> GetCategories()
        {
            Dictionary<int, string> categories = new Dictionary<int, string>();
            CreateSQLiteDBConnection();

            string sqliteQuery = "select * from tblCategories";
            SQLiteCommand command = new SQLiteCommand(sqliteQuery, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int categoryId = reader.GetInt32(0);
                string category = reader.GetString(1);
                categories.Add(categoryId, category);               
            }

            CloseSQLiteDBConnection();
            return categories;

        }

        public Dictionary<int, string> GetFinancialYears()
        {
            Dictionary<int, string> financialYears = new Dictionary<int, string>();
            CreateSQLiteDBConnection();

            string sqliteQuery = "select * from tblFinancialYear";
            SQLiteCommand command = new SQLiteCommand(sqliteQuery, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int financialYearId = reader.GetInt32(0);
                string financialYear = reader.GetString(1);
                financialYears.Add(financialYearId, financialYear);
            }

            CloseSQLiteDBConnection();
            return financialYears;

        }

        public Dictionary<int, string> GetIncomeSubCategories()
        {
            Dictionary<int, string> incomeSubCategories = new Dictionary<int, string>();
            CreateSQLiteDBConnection();

            string sqliteQuery = "select * from tblIncomeSubCategory";
            SQLiteCommand command = new SQLiteCommand(sqliteQuery, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int incomeSubCategoryId = reader.GetInt32(0);
                string incomeSubCategory = reader.GetString(1);
                incomeSubCategories.Add(incomeSubCategoryId, incomeSubCategory);
            }

            CloseSQLiteDBConnection();
            return incomeSubCategories;

        }

        public Dictionary<int, string> GetExpenditureSubCategories()
        {
            Dictionary<int, string> expenditureSubCategories = new Dictionary<int, string>();
            CreateSQLiteDBConnection();

            string sqliteQuery = "select * from tblExpenditureSubCategory";
            SQLiteCommand command = new SQLiteCommand(sqliteQuery, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int expenditureSubCategoryId = reader.GetInt32(0);
                string expenditureSubCategory = reader.GetString(1);
                expenditureSubCategories.Add(expenditureSubCategoryId, expenditureSubCategory);
            }

            CloseSQLiteDBConnection();
            return expenditureSubCategories;

        }
        
        private void CreateSQLiteDatabase()
        {

            SQLiteConnection.CreateFile(Constants.SQLiteDatabase);
        }

        private void CreateSQLiteTables()
        {

            CreateSQLiteDBConnection();
            string sqliteQuery = string.Empty;
            SQLiteCommand sqliteCommand;

            // Create tblAuditors
            sqliteQuery = "create table tblAuditors (AuditorId int PRIMARY KEY, UserId varchar(70), Password varchar(20))";
            sqliteCommand = new SQLiteCommand(sqliteQuery, m_dbConnection);
            sqliteCommand.ExecuteNonQuery();

            // Create tblClientInfo
            sqliteQuery = "create table tblClientInfo (PANNumber varchar(20) PRIMARY KEY, Name varchar(50), FatherOrHusbandName varchar(50), MobileNumber varchar(15), EmailId varchar(50), Address varchar(200), DateOfBirth varchar(10), AuditorId int)";
            sqliteCommand = new SQLiteCommand(sqliteQuery, m_dbConnection);
            sqliteCommand.ExecuteNonQuery();

            // Create tblClientInputData - To be added more columns            
            sqliteQuery = "create table tblClientInputData (InputDesc varchar(50), CategoryId int, FinancialYearId int, OpeningBalance float, "
                                                            + "Receipts float, PercentageOfPortionSold float, Payments float, InterestOnCapitalAmount float, "
                                                            + "Remuneration float, ShareOfProfitOrLoss float, InterestAccrued float, InterestReceived float, "
                                                            + "ClosingBalance float, IncomeSubCategoryId int, ExpenditureSubCategoryId int, PANNumber varchar(20))";
            sqliteCommand = new SQLiteCommand(sqliteQuery, m_dbConnection);
            sqliteCommand.ExecuteNonQuery();


            // Create tblCategory
            sqliteQuery = "create table tblCategory (CategoryId int, Category varchar(250))";
            sqliteCommand = new SQLiteCommand(sqliteQuery, m_dbConnection);
            sqliteCommand.ExecuteNonQuery();

            // Insert into tblCategory
            sqliteQuery = "insert into tblCategory (CategoryId, Category) values ";
            List<string> values = new List<string>();
            values.Add("(1, 'LIABILITIES')");
            values.Add("(2, 'FIXED ASSETS')");
            values.Add("(3, 'INVESTMENT IN FIRM')");
            values.Add("(4, 'DEPOSITS')");
            values.Add("(5, 'BANK ACCOUNTS')");
            values.Add("(6, 'OTHER ASSETS')");
            values.Add("(7, 'INCOME')");
            values.Add("(8, 'EXPENDITURE')");
            values.Add("(9, 'CAPITAL')");
            values.Add("(10, 'CASH')");
            foreach (string value in values)
            {                
                sqliteCommand = new SQLiteCommand(sqliteQuery+value, m_dbConnection);
                sqliteCommand.ExecuteNonQuery();
 
            }
            

            // Create tblFinancialYear
            sqliteQuery = "create table tblFinancialYear (FinancialYearId int, FinancialYear varchar(11))";
            sqliteCommand = new SQLiteCommand(sqliteQuery, m_dbConnection);
            sqliteCommand.ExecuteNonQuery();

            // Insert into tblFinancialYear
            sqliteQuery = "insert into tblFinancialYear (FinancialYearId, FinancialYear) values ";
            values.Clear();
            values.Add("(1, '2015-2016')");
            values.Add("(1, '2016-2017')");
            values.Add("(1, '2017-2018')");
            values.Add("(1, '2018-2019')");
            values.Add("(1, '2019-2020')");
            values.Add("(1, '2020-2021')");
            values.Add("(1, '2021-2022')");
            values.Add("(1, '2022-2023')");
            values.Add("(1, '2023-2024')");
            values.Add("(1, '2024-2025')");
            values.Add("(1, '2025-2026')");
            values.Add("(1, '2026-2027')");
            values.Add("(1, '2027-2028')");
            values.Add("(1, '2028-2029')");
            values.Add("(1, '2029-2030')");
            values.Add("(1, '2030-2031')");
            values.Add("(1, '2031-2032')");
            values.Add("(1, '2032-2033')");
            values.Add("(1, '2033-2034')");
            values.Add("(1, '2034-2035')");            
            foreach (string value in values)
            {                
                sqliteCommand = new SQLiteCommand(sqliteQuery+value, m_dbConnection);
                sqliteCommand.ExecuteNonQuery();
 
            }

            // Create table tblIncomeSubCategory
            sqliteQuery = "create table tblIncomeSubCategory (IncomeSubCategoryId int, IncomeSubCategory varchar(50))";
            sqliteCommand = new SQLiteCommand(sqliteQuery, m_dbConnection);
            sqliteCommand.ExecuteNonQuery();

            // Insert into table tblIncomeSubCategory
            sqliteQuery = "insert into tblIncomeSubCategory (IncomeSubCategoryId, IncomeSubCategory) values ";
            values.Clear();
            values.Add("(1, 'SALARY INCOME')");
            values.Add("(2, 'RENTAL INCOME')");
            values.Add("(3, 'BUSINESS / PROFESSION INCOME')");
            values.Add("(4, 'OTHER INCOME')");
            values.Add("(5, 'AGRICULTURAL INCOME')");
            foreach (string value in values)
            {
                sqliteCommand = new SQLiteCommand(sqliteQuery + value, m_dbConnection);
                sqliteCommand.ExecuteNonQuery();
            }

            
            // Create table tblExpenditureSubCategory
            sqliteQuery = "create table tblExpenditureSubCategory (ExpenditureSubCategoryId int, ExpenditureSubCategory varchar(50))";
            sqliteCommand = new SQLiteCommand(sqliteQuery, m_dbConnection);
            sqliteCommand.ExecuteNonQuery();

            // Insert into table tblExpenditureSubCategory
            sqliteQuery = "insert into tblExpenditureSubCategory (ExpenditureSubCategoryId, ExpenditureSubCategory) values ";
            values.Clear();
            values.Add("(1, 'SALARY EXPENDITURE')");
            values.Add("(2, 'RENTAL EXPENDITURE')");
            values.Add("(3, 'BUSINESS / PROFESSION EXPENDITURE')");
            values.Add("(4, 'OTHER EXPENDITURE')");
            values.Add("(5, 'AGRICULTURAL EXPENDITURE')");
            values.Add("(6, 'PERSONAL EXPENDITURE')");
            foreach (string value in values)
            {
                sqliteCommand = new SQLiteCommand(sqliteQuery + value, m_dbConnection);
                sqliteCommand.ExecuteNonQuery();
            }


            CloseSQLiteDBConnection();

        }

        private void CreateSQLiteDBConnection()
        {
            m_dbConnection = new SQLiteConnection("Data Source=SQLiteDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

        }

        private void CloseSQLiteDBConnection()
        {
            m_dbConnection.Close();
            m_dbConnection.Dispose();            
        }
    }
}
