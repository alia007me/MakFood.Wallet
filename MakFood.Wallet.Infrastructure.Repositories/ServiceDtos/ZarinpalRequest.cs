using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.Repositories.ServiceDtos
{
    public class ZarinpalRequest
    {
        public string merchant_id { get; set; } = default!;
        public int amount { get; set; }
        public string callback_url { get; set; } = default!;
        public string description { get; set; } = default!;
        public object? metadata { get; set; }
    }
}
