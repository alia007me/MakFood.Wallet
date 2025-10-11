using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.Dtos.ServiceDtos
{
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
