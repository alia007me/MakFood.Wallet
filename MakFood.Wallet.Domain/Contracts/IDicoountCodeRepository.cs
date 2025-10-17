using MakFood.Wallet.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Contracts
{
    public interface IDicoountCodeRepository
    {

        public void AddDicoountCode(Guid CustomerId, decimal MaximumDiscount, decimal MinimumDiscount
            , float Percentage, DateOnly ExpirationDate);


        public  Task<DiscountCode> GetDiscountCodeByID(Guid? DiscountId);
    }
}
