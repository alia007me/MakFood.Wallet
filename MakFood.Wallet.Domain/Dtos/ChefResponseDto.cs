using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Dtos
{
    public class ChefResponseDto
    {
        public Guid Walletid { get; set; }
        public Decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
    }
}
