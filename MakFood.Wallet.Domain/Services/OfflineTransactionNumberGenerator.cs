using MakFood.Wallet.Domain.Model.Contracts;
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
        private readonly IWalletRepository _walletRepository;

        public OfflineTransactionNumberGenerator(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public string GenerateTransactionNumber()
        {
            var time = DateTime.Now;
            var TransactionNumber = new StringBuilder();
            var EventCounts = _walletRepository.TransactionCounts();
            TransactionNumber.Append(EventCounts + 1);
            TransactionNumber.Append(time.Year);
            TransactionNumber.Append(time.Month);
            TransactionNumber .Append(time.Day);
            TransactionNumber.Append(time.Hour);
            TransactionNumber.Append(time.Minute);

            return TransactionNumber.ToString();


        }
    }
}
