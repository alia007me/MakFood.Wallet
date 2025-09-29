using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MakFood.Wallet.Application.DTOs.ChargeBalanceDTO
{
    public class ChargeBalanceWriteDTO
    {
        public Guid Id { get;  set; }
        public Decimal Amount { get;  set; }
        public string Email { get;  set; }
        public string description { get;  set; }
    }
}
