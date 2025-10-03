using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Entities.TransactionAggregate
{
    public class ChargeTransaction : Transaction
    {
        public ChargeTransaction(decimal transactionAmount,string transactionNumber,DateTime transactionDate) : base(transactionAmount,transactionNumber,transactionDate)
        { }
        public ChargeTransaction(decimal transactionAmount, string transactionNumber, DateTime transactionDate,Guid walletId,ChargeModelStatus status, ChargeModelState state)
            : base(transactionAmount, transactionNumber, transactionDate)
        {
            WalletId = walletId;
            ChargeStatus = status;
            ChargeState = state;
        }

        public Guid TransactionId { get; private set; }
        public ChargeModelStatus ChargeStatus { get; private set; }
        public ChargeModelState ChargeState { get; set; }

        public Guid WalletId { get; private set; }
        public Wallet Wallet { get;  set; }





    }
}
