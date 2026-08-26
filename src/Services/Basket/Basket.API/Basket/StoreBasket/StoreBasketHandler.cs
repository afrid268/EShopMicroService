
namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
public record StoreBasketResult(string userName);
public class StoreBaskerCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBaskerCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart cannot be empty");
        RuleFor(x => x.Cart.UserName).NotNull().WithMessage("UserName is Required");
    }
}

public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
       ShoppingCart cart = command.Cart;

        return new StoreBasketResult("user - 007");
    }
}