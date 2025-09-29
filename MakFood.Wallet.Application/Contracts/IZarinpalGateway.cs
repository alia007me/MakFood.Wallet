using MakFood.Wallet.Application.DTOs.ZarinpalGatewayDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.Contracts
{
    public interface IZarinpalGateway
    {
        Task<ZarinpalRequestResponse> PayRequest(decimal amount ,string email , string description);
        
    }
}
