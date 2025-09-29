using MakFood.Wallet.Application.Contracts;
using MakFood.Wallet.Application.DTOs.ChargeBalanceDTO;
using MakFood.Wallet.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.Repositories.Repositories
{
    public class ChargeRepository : IChargeRepository
    {
        private readonly MakFoodWalletDbContext _context;
        private readonly IZarinpalGateway _zarinpalGateway;

        public ChargeRepository(MakFoodWalletDbContext context, IZarinpalGateway zarinpalGateway)
        {
            _context = context;
            _zarinpalGateway = zarinpalGateway;
        }

        public Task<bool> ChargeBalanceOfflineAsync(Guid id, decimal Amount)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ChargeBalanceOnlineAsync(ChargeBalanceWriteDTO chargeBalance)
        {
            var Wallet = await _context.Wallets.SingleOrDefaultAsync(x => x.WalletId == chargeBalance.Id);
            if (Wallet == null)
                return "Invalid";
            var PaymentResult = await _zarinpalGateway.PayRequest(chargeBalance.Amount, chargeBalance.Email, chargeBalance.description);
            if (PaymentResult.data.code == 100)
            {

                await _context.ChargeTransactions.AddAsync(
                new Domain.Model.Entities.TransactionAggregate.ChargeTransaction(

                chargeBalance.Amount,
                PaymentResult.data.authority,
                System.DateTime.Now,
                chargeBalance.Id


                ));
                await _context.SaveChangesAsync();
                return PaymentResult.data.authority;
                /*Wallet.IncreaseBalance(chargeBalance.Amount);
                await _context.SaveChangesAsync();
                return true;*/
            }
            return "Invalid";


        }
    }
}
