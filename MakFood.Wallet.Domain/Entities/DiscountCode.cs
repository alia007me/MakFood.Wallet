using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Entities
{
    public class DiscountCode
    {
        public DiscountCode(Guid CustomerId, decimal MaximumDiscount, decimal MinimumDiscount, float Percentage, DateOnly ExpirationDate)
        {
            this.CustomerId = CustomerId;
            this.MaximumDiscount = MaximumDiscount;
            this.MinimumDiscount = MinimumDiscount;
            this.Percentage = Percentage;
            this.ExpirationDate = ExpirationDate;
        }
        public Guid DiscountId { get; private set; }
        public Guid CustomerId { get; private set; }
        public Decimal MaximumDiscount { get; private set; }
        public Decimal MinimumDiscount { get; private set; }
        public float Percentage { get; private set; }
        public DateOnly ExpirationDate { get; private set; }

    }
}
