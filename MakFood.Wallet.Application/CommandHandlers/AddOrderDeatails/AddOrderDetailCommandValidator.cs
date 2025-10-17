using FluentValidation;

namespace MakFood.Wallet.Application.CommandHandlers.AddOrderDeatails
{
    public class AddOrderDetailCommandValidator : AbstractValidator<AddOrderDetailCommand>
    {
        public AddOrderDetailCommandValidator() {
            RuleFor(x => x.OrderAmount).NotEmpty().NotNull().GreaterThan(0);
        }
        
    }
}
