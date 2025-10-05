using MakFood.Wallet.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Entities
{
    public class OrderDetails
    {
        public OrderDetails(decimal OrderAmount, Guid DiscountCodeID, PaymentType PaymentType, decimal TotalPaid)
        {
            this.OrderAmount = OrderAmount;
            this.DiscountCodeID = DiscountCodeID;
            this.PaymentType = PaymentType;
            this.TotalPaid = TotalPaid;
        }
        public Guid OrderDetailId { get; private set; }
        public Decimal OrderAmount { get; private set; }
        public Guid DiscountCodeID { get; private set; }
        public PaymentType PaymentType { get; private set; }
        public Decimal TotalPaid { get; private set; }



        public Guid WalletId { get; private set; }
        public Wallet Wallet { get; private set; }
    }
}
