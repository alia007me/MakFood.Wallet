using Application.Commands.WithdrawWallet;
using MakFood.Wallet.Application.CommandHandlers.RefundOfWallet;
using MakFood.Wallet.Domain.Model.Contracts;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RefundOfWalletController : ControllerBase
{
    private readonly RefundOfWalletCommandHandller _handler;

    public RefundOfWalletController(IWalletRepository walletRepository)
    {
        _handler = new RefundOfWalletCommandHandller(walletRepository);
    }

    [HttpPost("RefundOfWallet")]
    public async Task<IActionResult> RefundOfWallet([FromBody] RefundOfWalletCommand command)
    {
        var result = await _handler.HandleAsync(command);
        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}