using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Wallet.Domain.Model.Services.Contract
{
    public interface IOfflineTransactionNumberGenerator
    {
        string GenerateTransactionNumber();
        
    }
}
