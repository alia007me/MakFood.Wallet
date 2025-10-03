using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Dtos
{
    public class ChargeBalanceOfflineWriteDto
    {
        public Guid Walletid { get; set; }
        public Decimal Amount { get; set; }
        [JsonIgnore]
        public CancellationToken CancellationToken { get; set; }



    }
}
