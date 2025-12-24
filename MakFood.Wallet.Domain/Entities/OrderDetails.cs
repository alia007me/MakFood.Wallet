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
        public OrderDetails(decimal OrderAmount)
        {
            this.OrderAmount = OrderAmount;
            this.OrderDetailId= Guid.NewGuid();
        }
        public Guid OrderDetailId { get; private set; }
        public Decimal OrderAmount { get; private set; }
        public bool isPaied { get; private set; } = false;

        public void pay()
        {
            this.isPaied = true;
        }
    }
}
