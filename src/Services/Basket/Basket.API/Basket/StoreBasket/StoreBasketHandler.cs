
namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
public record StoreBasketResult(string UserName);
public class StoreBaskerCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBaskerCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart cannot be empty");
        RuleFor(x => x.Cart.UserName).NotNull().WithMessage("UserName is Required");
    }
}

public class StoreBasketCommandHandler (IBasketRepository repository) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        ShoppingCart cart = command.Cart;
        await repository.StoreBasket(command.Cart, cancellationToken);

        return new StoreBasketResult(command.Cart.UserName);
    }
}