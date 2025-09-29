using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Contracts.DTOs
{
    public class ChargeBalanceWriteDTO
    {
        public Guid Id { get;  set; }
        public decimal Amount { get;  set; }
        public string Email { get;  set; }
        public string description { get;  set; }
    }
}
