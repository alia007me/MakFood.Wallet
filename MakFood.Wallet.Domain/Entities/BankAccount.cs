using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Entities
{
    public class BankAccount
    {
        private BankAccount() { }
        private string _accountnumber;
        
        public BankAccount(Guid AccountId, string Name, string AccountNumber, DateOnly ExpiredDate)
        {
            this.AccountId = AccountId;
            this.Name = Name;
            this.AccountNumber = AccountNumber;
            this.ExpiredDate = ExpiredDate;
        }

        public Guid AccountId { get; private set; }
        public string Name { get; private set; }
        public string AccountNumber
        {
            get => _accountnumber;
            private set
            {
                string pattern = @"/^(?:\d{4}-){3}\d{4}$/";
                if (!Regex.IsMatch(value, pattern))
                    throw new Exception("Please Enter Your PhoneNumber Correctly");
                _accountnumber = value;

            }
        }
        public DateOnly ExpiredDate { get; private set; }
    }

}
