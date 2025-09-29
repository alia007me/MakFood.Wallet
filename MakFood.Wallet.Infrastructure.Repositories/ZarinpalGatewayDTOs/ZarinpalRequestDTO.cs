using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.Repositories.ZarinpalGatewayDTOs
{
    public class ZarinpalRequestDTO
    {
        public Decimal Amount { get; private set; }
        public string Email { get; private set; }
        public string description { get; private set; }
    }
}
