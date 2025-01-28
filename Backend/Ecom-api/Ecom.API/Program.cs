using Ecom.API.GrpcServices;
using Ecom.API.Interceptors;
using Ecom.API.Mapping;
using Ecom.Infrastructure;
using Ecom.Application;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the container.
builder.Services.AddGrpc(option => { option.Interceptors.Add<CallProcessingInterceptor>(); });
builder.Services.AddGrpcReflection();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.MappingConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

// Configure the HTTP request pipeline.
app.MapGrpcService<ProductGrpcService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.Run();
