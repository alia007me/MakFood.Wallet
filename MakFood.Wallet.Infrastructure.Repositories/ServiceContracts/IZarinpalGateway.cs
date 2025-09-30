using MakFood.Wallet.Infrastructure.Repositories.ServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.Repositories.Contracts
{
    public interface IZarinpalGateway
    {
        Task<ZarinpalRequestResponse> PayRequest(decimal amount ,string email , string description);
        
    }
}
