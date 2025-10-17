using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Domain.Model.Entities;
using MakFood.Wallet.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.Repositories.Repositories
{
    public class DicoountCodeRepository : IDicoountCodeRepository
    {
        private readonly MakFoodWalletDbContext _context;
        public  DicoountCodeRepository(MakFoodWalletDbContext context)
        {
            _context = context;
        }
        public void AddDicoountCode(Guid CustomerId, decimal MaximumDiscount, decimal MinimumDiscount
            , float Percentage, DateOnly ExpirationDate)
        {
            _context.DiscountCodes.Add(new DiscountCode(CustomerId, MaximumDiscount, MinimumDiscount
            , Percentage, ExpirationDate));

        }

        public async  Task<DiscountCode> GetDiscountCodeByID(Guid? DiscountId) {
            var DicountCode =await _context.DiscountCodes.SingleOrDefaultAsync(x => x.DiscountId == DiscountId);
            return DicountCode;
        }
    }
}
