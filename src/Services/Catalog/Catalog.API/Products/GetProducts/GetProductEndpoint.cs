
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProducts
{

    //public record GetProductRequest();
    public record GetProductResponse(IEnumerable<Product> Products);


    public class GetProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());
                var response = result.Adapt<GetProductResponse>();// mapster in that way we can directly pass result object
                //to do response object, paramters name should be exact the name


                return Results.Ok(result);
                
            })
                .WithName("GetProduct")
                .Produces<GetProductResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Product")
                .WithDescription("Get Products");




            
        }
    }
}
