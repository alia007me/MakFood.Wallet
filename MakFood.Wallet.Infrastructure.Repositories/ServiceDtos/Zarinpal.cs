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

    public class ZarinpalVerify
    {
        public string merchant_id { get; set; } = default!;
        public string authority { get; set; } = default!;
        public int amount { get; set; }
    }

    public class ZarinpalVerifyResponse
    {
        public Data data { get; set; } = default!;
        public class Data
        {
            public int code { get; set; }
            public string message { get; set; } = default!;
            public long ref_id { get; set; }
            public string card_pan { get; set; } = default!;
            public string card_hash { get; set; } = default!;
        }
    }
}
