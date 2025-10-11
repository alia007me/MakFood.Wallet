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
        public OrderDetails(decimal OrderAmount, Guid DiscountCodeID,/* PaymentType PaymentType,*/ decimal TotalAmount)
        {
            this.OrderAmount = OrderAmount;
            this.DiscountCodeID = DiscountCodeID;
            //this.PaymentType = PaymentType;
            this.TotalAmount = TotalAmount;
        }
        public Guid OrderDetailId { get; private set; }
        public Decimal OrderAmount { get; private set; }
        public Guid DiscountCodeID { get; private set; }
        //public PaymentType PaymentType { get; private set; }
        public Decimal TotalAmount { get; private set; }
        public Guid WalletId { get; private set; }
    }
}
