namespace Application.Commands.WithdrawWallet
{


    public class RefundOfWalletCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public decimal? RemainingBalance { get; set; }

        public static RefundOfWalletCommandResponse Ok(decimal balance, string msg = "Withdrawal successful.")
            => new() { Success = true, Message = msg, RemainingBalance = balance };

        public static RefundOfWalletCommandResponse Fail(string msg)
            => new() { Success = false, Message = msg };
    }
}