using MakFood.Wallet.Infrastructure.Repositories.Contracts;
using MakFood.Wallet.Domain.Model.Dtos;
using MakFood.Wallet.Domain.Model.Contracts;
using MakFood.Wallet.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using MakFood.Wallet.Infrastructure.Repositories.ServiceDtos;

namespace MakFood.Wallet.Infrastructure.Repositories.Repositories
{
    public class ChargeRepository : IChargeRepository
    {
        private readonly MakFoodWalletDbContext _context;
        private readonly IZarinpalGateway _zarinpalGateway;
        private readonly ConcurrentDictionary<Guid, decimal> _pendingrequests = new ConcurrentDictionary<Guid, decimal>();

        public ChargeRepository(MakFoodWalletDbContext context, IZarinpalGateway zarinpalGateway)
        {
            _context = context;
            _zarinpalGateway = zarinpalGateway;
        }

        public async Task<bool> ChargeBalanceOffline(ChargeBalanceOfflineWriteDto chargeBalance)
        {
            var wallet = await _context.Wallets.SingleOrDefaultAsync(x=>x.CustomerId == chargeBalance.CustomerId);
            if (wallet == null)
            {
                return false;
            }
            var random = new Random();
            string number = random.Next(100000, 1000000).ToString();
            var result = await _context.ChargeTransactions.AddAsync
                (new Domain.Model.Entities.TransactionAggregate.ChargeTransaction
                (chargeBalance.Amount,number,DateTime.Now,wallet.WalletId,
                Domain.Model.Enums.ChargeModelStatus.Offline,Domain.Model.Enums.ChargeModelState.Pending));
            await _context.SaveChangesAsync();
            return true;



        }
        public async Task<string> CheckChefResponseAsync(ChefResponseDto chargeBalance)
        {
            var wallet = await _context.Wallets.SingleOrDefaultAsync(x=>x.CustomerId == chargeBalance.CustomerId);
            if (wallet == null)
                return "Wallet Not Found";
            else
            {
                var result = await _context.ChargeTransactions.SingleOrDefaultAsync
                    (x=>x.WalletId == wallet.WalletId && x.TransactionDate == chargeBalance.DateTime && x.TransactionAmount == chargeBalance.Amount);
                if (result == null)
                {
                    _context.ChargeTransactions.Remove(result);
                    return "Chef Didn't Accept Your Request ! Talk With Him/Her For Issue";
                }
                else
                {
                    wallet.IncreaseBalance(chargeBalance.Amount);
                    result.ChargeState = Domain.Model.Enums.ChargeModelState.Complete;
                    await _context.SaveChangesAsync();
                    return $"Your Wallet Charged SuccessFully ! Your Current Balance {wallet.AvailableBalance}";
                }
            }
        }

        public async Task<string> ChargeBalanceOnlineAsync(ChargeBalanceOnlineWriteDto chargeBalance)
        {
            var Wallet = await _context.Wallets.SingleOrDefaultAsync(x => x.WalletId == chargeBalance.Id , chargeBalance.CancellationToken);
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
                chargeBalance.Id,
                Domain.Model.Enums.ChargeModelStatus.Online,
                Domain.Model.Enums.ChargeModelState.Pending
                


                ));
                await _context.SaveChangesAsync(chargeBalance.CancellationToken
                    );
                return PaymentResult.data.authority;
                /*Wallet.IncreaseBalance(chargeBalance.Amount);
                await _context.SaveChangesAsync();
                return true;*/
            }
            return "Invalid";


        }


    }
}
