using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Infrastructure.Repositories.ServiceDtos
{
    public class ZarinpalRequestResponse
    {
        public Data data { get; set; } = default!;
        public class Data
        {
            public int code { get; set; }
            public string message { get; set; } = default!;
            public string authority { get; set; } = default!;
            public string fee_type { get; set; } = default!;
            public int fee { get; set; }
        }
    }
}
