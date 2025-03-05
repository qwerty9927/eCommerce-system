using Identity_api.Configurations;
using Identity_api.Helpers;
using Identity_api.Interceptors;
using Identity_api.Interfaces.WebApi;
using Identity_api.Models;
using Identity_api.Repositories;
using Identity_api.Services;
using Identity_api.WebApi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddGrpc(option => { option.Interceptors.Add<CallProcessingInterceptor>(); });
builder.Services.AddGrpcReflection();

// Db config
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
});

builder.Services.AddAuthorization();

builder.Services.AddIdentity<UserModel, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager<SignInManager<UserModel>>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

// External utilities
builder.Host.UseSerilog((context, configuration) => configuration
    .WriteTo.Console(
        outputTemplate:
        "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
    .ReadFrom.Configuration(context.Configuration));

// Configuration
builder.Services.Configure<OpenIDConnectSettings>(
    builder.Configuration.GetSection(nameof(OpenIDConnectSettings)));

// DI
builder.Services.AddScoped<IIdentityProviderApi, IdentityProviderApi>();

// Http DI setup
builder.Services.AddHttpClient<RestHttpClientHelper>();
builder.Services.AddHttpClient<GrpcHttpClientHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<AuthService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.UseSerilogRequestLogging();
app.MapGrpcReflectionService();
app.UseAuthentication();
app.UseAuthorization();
app.Run();