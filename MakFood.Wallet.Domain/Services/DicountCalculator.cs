using MakFood.Wallet.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Services
{
    public static class DicountCalculator
    {
        public static decimal ApplyDicount(this decimal amount, DiscountCode Discount,Guid walletID)
        {
            if (Discount.ExpirationDate < DateOnly.FromDateTime(DateTime.Now)) {
                throw new Exception("This code is expierd");
            }
            else if (Discount.CustomerId != walletID) {
                throw new Exception("this is not your code");
            }

            else if (amount < Discount.MinimumDiscount) {
                throw new Exception("your order is so cheep for this dicont code");
            }
            else if (amount > Discount.MaximumDiscount) {
                return (amount - Discount.MaximumDiscount * Convert.ToDecimal(Discount.Percentage));
            }
            else {
                return (amount * Convert.ToDecimal(Discount.Percentage));
            }

        }
    }
}
