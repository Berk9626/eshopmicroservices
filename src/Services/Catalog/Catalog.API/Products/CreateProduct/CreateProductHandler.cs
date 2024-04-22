


namespace Catalog.API.Products.CreateProduct
{//application logic layer
    //record: genellikle veri taşıyan, sorgulanan veya tutulan nesnelerin tanımlanmasında kullanılır. record ifadesi, genellikle sadece veri tutan ve değişmez (immutable) nesnelerin tanımlanmasında tercih edilir.



    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;


    public record CreateProductResult(Guid Id); 

    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    //bizim command ve result clasları üretilecek
    //kelimesi bir türün veya üyenin yalnızca tanımlandığı derleme biriminde erişilebilir olduğunu belirtir. Bu, kodunuzun daha iyi modülerlik ve izolasyon sağlamasına yardımcı olabilir.
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //bu method perform the bussiness logic to create a product
            //create product entity
            //save to database
            //return result

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price


            };
            //save to db
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken); 
            

            return new CreateProductResult(product.Id);




           
        }
    }
}
