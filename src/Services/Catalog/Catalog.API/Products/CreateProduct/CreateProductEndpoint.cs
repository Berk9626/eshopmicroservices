
namespace Catalog.API.Products.CreateProduct
{//presentation :) //bu telefonda yer alan şekildeki request ve response öğeleri


    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);//this will be including all items in the product model class
    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint : ICarterModule //carter kullanımı, burda aslında post methodu için ele aldık.
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>(); //mapped
                //bizim mediatr requiring command obj. in order to trigger our command handler
                var result = await sender.Send(command);//send mediatr
                //now start the medaitor and triggered the handler class...
                var response = result.Adapt<CreateProductResponse>();
                return Results.Created($"/products/{response.Id}", response);
            })
                .WithName("CreateProduct")
                .Produces<CreateProductResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Create Product")
                .WithDescription("Create Product");
           
        }
    }

    //biz burda request ürettik. Ardından mediatr'yi kullandık ve mediatr handler classı triggerladık. Ardından değerleri 
    //request objectten, handler command objecte geçirdik(createProductCommandHandler) Burdan geçtikten sonra da mappinge ihtiyaç oldu
    //şekilde requestten commandquery'e geçiş için mapping yapmamız gerektiğini anladık.how we can convert to request to command obj ?
    //(Mapping libr.) = Mapster we will use mapster in order to convert our request module to the mediator command object and vice verca
    //
}
