using MakFood.Wallet.Domain.Model.Entities.TransactionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Entities
{
    public class Wallet
    {
        public Wallet() { }
        public Wallet(Guid CustomerId, Decimal Balance, Decimal AvailableBalance)
        {
            this.CustomerId = CustomerId;
            this.Balance = Balance;

        }
        public Guid WalletId { get; private init; }
        public Guid CustomerId { get; private init; }
        public Decimal Balance { get; private set; }
        public Decimal AvailableBalance => Balance - 10000;




        public IList<Accounts> Accounts { get; private set; } = new List<Accounts>();
        public IList<ChargeTransaction> chargeTransactions { get; private set; } = new List<ChargeTransaction>();
        public IList<RefundTransaction> refundTransactions { get; private set; } = new List<RefundTransaction>();
        public IList<OrderDetails> OrderDetails { get; private set; } = new List<OrderDetails>();



        public void IncreaseBalance(decimal amount)
        {
            if (amount <= 0)
                throw new InvalidOperationException("Amount must be positive.");

            Balance += amount;
        }
    }
}
