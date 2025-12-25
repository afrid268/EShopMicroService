
namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductCommandResponse>;
    public record DeleteProductCommandResponse(bool IsSuccess);
    internal class DeleteProductCommandHandler (IDocumentSession session, ILogger<DeleteProductCommandHandler> logger) : ICommandHandler<DeleteProductCommand, DeleteProductCommandResponse>
    {
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("DeleteProductHandler.Handle called with {@Command},command");

            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

            if (product == null)
            {
                throw new ProductNotFoundException();
            }

            session.Delete<Product>(command.Id);
            await session.SaveChangesAsync(cancellationToken);

            return new DeleteProductCommandResponse(true);
        }
    }
}
