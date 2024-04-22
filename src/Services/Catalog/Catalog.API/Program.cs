var builder = WebApplication.CreateBuilder(args);

//add services to the container
builder.Services.AddCarter();//Carter maps the routes defined in the ICarter modeule implementation
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);// we gonna register all services into this project, into the 
    //... mediator class library

});
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

//configure the http request pipeline


app.MapCarter();

app.Run();
