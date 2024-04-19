using MediatR;

namespace Catalog.API.Products.CreateProduct
{//application logic layer
    //record: genellikle veri taşıyan, sorgulanan veya tutulan nesnelerin tanımlanmasında kullanılır. record ifadesi, genellikle sadece veri tutan ve değişmez (immutable) nesnelerin tanımlanmasında tercih edilir.


    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : IRequest<CreateProductResult>;
    public record CreateProductResult(Guid Id); 

    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    //bizim command ve result clasları üretilecek
    //kelimesi bir türün veya üyenin yalnızca tanımlandığı derleme biriminde erişilebilir olduğunu belirtir. Bu, kodunuzun daha iyi modülerlik ve izolasyon sağlamasına yardımcı olabilir.
    {
        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //bu method perform the bussiness logic to create a product
            throw new NotImplementedException();
        }
    }
}
