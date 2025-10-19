using MakFood.Wallet.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Contracts
{
    public interface IOrderDetailsRepository
    {

        public Task<OrderDetails> GetOrderDetailsByID(Guid ID, CancellationToken ct);

        public void AddOrderDetails(Guid WalletId, decimal OrderAmount, Guid? DiscountCodeID,decimal TotalAmount);
        
    }
}
