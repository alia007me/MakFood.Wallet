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
        public OrderDetails( decimal OrderAmount, Guid? DiscountCodeID, decimal TotalAmount)
        {
            this.OrderAmount = OrderAmount;
            this.DiscountCodeID = DiscountCodeID;
            this.TotalAmount = TotalAmount;
            //this.WalletId = WalletId;
        }
        public OrderDetails(decimal OrderAmount)
        {
            this.OrderAmount = OrderAmount;
            this.DiscountCodeID = DiscountCodeID;
            this.TotalAmount = OrderAmount;
            //this.WalletId = WalletId;
        }
        public Guid OrderDetailId { get; private set; }= Guid.NewGuid();
        public Decimal OrderAmount { get; private set; }
        public Guid? DiscountCodeID { get; private set; }
        //public PaymentType PaymentType { get; private set; }
        public Decimal TotalAmount { get; private set; } 
        //public Guid WalletId { get; private set; }
        public bool isPaied { get; private set; } = false;

        public void pay()
        {
            this.isPaied = true;
        }
    }
}
