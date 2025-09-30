using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Dtos
{
    public class ChargeBalanceOnlineWriteDto
    {
        public Guid Id { get;  set; }
        public decimal Amount { get;  set; }
        public string Email { get;  set; }
        public string description { get;  set; }
        [JsonIgnore]
        public CancellationToken CancellationToken { get; set; }
    }
}
