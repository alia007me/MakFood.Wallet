using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.Dtos.ServiceDtos
{
    public class ZarinpalVerify
    {
        public string merchant_id { get; set; } = default!;
        public string authority { get; set; } = default!;
        public int amount { get; set; }
    }
}
