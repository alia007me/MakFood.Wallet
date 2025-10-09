//using MakFood.Wallet.Domain.Model.Base;
//using MakFood.Wallet.Domain.Model.Contracts;
//using MakFood.Wallet.Domain.Model.Events.WalletEvents;
//using MakFood.Wallet.Domain.Model.Services.Contract;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MakFood.Wallet.Domain.Model.Services
//{

//    public class ReplyEventService
//    {
//        private readonly IReplyEventRepository _ReplyEvent;


//        public  ReplyEventService(IReplyEventRepository reply )
//        {
//            _ReplyEvent = reply;
//        }
//        public async Task<Entities.Wallet> ReplyEventBeforeTime(Guid id, DateTime time, CancellationToken ct)
//        {
//            var primitiveWallet = Entities.Wallet.Primitive;
//            var events = await (_ReplyEvent.GetWaletEvent(id, time, ct));
//            foreach (var @event in events) {
//                primitiveWallet.Apply(EventFactoryExtantion.GenerateEvent(@event));
//            }
//            return primitiveWallet;
//        }
//    }
//}
 