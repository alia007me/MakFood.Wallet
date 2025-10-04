using MakFood.Wallet.Domain.Model.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Services
{
    public class OfflineTransactionNumberGenerator : IOfflineTransactionNumberGenerator
    {
        
        public string GenerateTransactionNumber()
        {
            var time = DateTime.Now;
            var TransactionNumber = new StringBuilder();
            TransactionNumber.Append(time.Year);
            TransactionNumber.Append(time.Month);
            TransactionNumber .Append(time.Day);
            TransactionNumber.Append(time.Hour);
            TransactionNumber.Append(time.Minute);

            return TransactionNumber.ToString();


        }
    }
}
