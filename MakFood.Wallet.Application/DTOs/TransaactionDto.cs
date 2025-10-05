using System;
using MakFood.Wallet.Domain.Model.Enums;
namespace MakFood.Wallet.Application.DTOs
{
    public class TransaactionDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Created { get; set; }
        public string TrackingCode { get; set; }
        public string TransactionType { get; set; }
        public PaymentType PaymentType { get; set; }

    }
}