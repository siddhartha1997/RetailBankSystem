using AccountMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Repository
{
    public class GetListRep : IGetListRep
    {
        public List<AccountStatement> GetAccountStatementsList()
        {
            List<AccountStatement> accountStatements = new List<AccountStatement>()
            {
                new AccountStatement{AccId=102,
                    Statements= new List<Statement>()
                    {
                    new Statement{date=01022020,Narration="Transfer to XY",refno=12345,valueDate=01022020,withdrawal=1000.00,deposit=0.00,closingBalance=1000.00},

                    new Statement{date=04022020,Narration="Transfer from XYZ",refno=21345,valueDate=04022020,withdrawal=0.00,deposit=2000.00,closingBalance=3000.00}
                    }
                } 
            };
            return accountStatements;
        }

        public List<CurrentAccount> GetCurrentAccountsList()
        {
            List<CurrentAccount> currentAccounts = new List<CurrentAccount>()
            {
                new CurrentAccount{CAId=101,CBal=1000}
            };
            return currentAccounts;
        }

        public List<customeraccount> GetCustomeraccountsList()
        {
            List<customeraccount> customeraccounts = new List<customeraccount>()
            {
                new customeraccount{custId=1,CAId=101,SAId=102}
            };
            return customeraccounts;
        }

        public List<SavingsAccount> GetSavingsAccountsList()
        {
            List<SavingsAccount> savingsAccounts = new List<SavingsAccount>()
            {
                new SavingsAccount{SAId=102,SBal=500}
            };
            return savingsAccounts;
        }

        /*public List<Statement> GetStatementsList()
        {
            throw new NotImplementedException();
        }*/
    }
}
