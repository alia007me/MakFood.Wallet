using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Entities.TransactionAggregate
{
    public class Transaction
    {
        public Transaction(decimal TransactionAmount, string TransactionNumber, DateTime TransactionDate)
        {
            this.TransactionAmount = TransactionAmount;
            this.TransactionNumber = TransactionNumber;
            this.TransactionDate = TransactionDate;
        }

        public decimal TransactionAmount { get; protected set; }
        public string TransactionNumber { get; protected set; }
        public DateTime TransactionDate { get; protected set; }



        public void UpdateTransactionNumber(string TransactionNumberr)
        {
            TransactionNumber = TransactionNumberr;
        }
    }
}
