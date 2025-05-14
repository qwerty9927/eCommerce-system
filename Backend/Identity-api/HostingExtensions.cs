using System.Reflection;
using Identity_api.Configurations;
using Identity_api.Extensions;
using Identity_api.Helpers;
using Identity_api.Interfaces.Service;
using Identity_api.Middlewares;
using Identity_api.Models;
using Identity_api.Repositories;
using Identity_api.Pages.Admin.ApiScopes;
using Identity_api.Pages.Admin.Clients;
using Identity_api.Pages.Admin.IdentityScopes;
using Identity_api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Identity_api;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add Core Services
        builder.Services.AddRazorPages();
        builder.Services.AddControllers();

        // Configure Database (EF Core)
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString,
                dbOpts => dbOpts.MigrationsAssembly(typeof(Program).Assembly.FullName)));
        
        // Configure memory cache
        builder.Services.AddMemoryCache();

        // Configure Identity
        builder.Services.AddIdentity<UserModel, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        // Configure Identity Options
        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 8;

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = false;
        });

        // Configure Logging (Serilog)
        builder.Host.UseSerilog((context, configuration) => configuration
            .WriteTo.Console(
                outputTemplate:
                "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
            .ReadFrom.Configuration(context.Configuration));

        // Configure IdentityServer
        builder.Services
            .AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
            })
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b =>
                    b.UseSqlServer(connectionString,
                        dbOpts => dbOpts.MigrationsAssembly(typeof(Program).Assembly.FullName));
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b =>
                    b.UseSqlServer(connectionString,
                        dbOpts => dbOpts.MigrationsAssembly(typeof(Program).Assembly.FullName));
            })
            .AddAspNetIdentity<UserModel>();

        // Configure Authentication & JWT Bearer
        var openIdConnectSettings =
            builder.Configuration.GetSection("OpenIDConnectSettings").Get<OpenIDConnectSettings>() ?? new();
        
        builder.Services.AddJWTServices(openIdConnectSettings);

        // builder.Services.AddAuthentication(options =>
        //     {
        //         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //     })
        //     .AddJwtBearer(options =>
        //     {
        //         options.Authority = openIdConnectSettings.Authority;
        //         options.RequireHttpsMetadata = false; // Set to true in production
        //         options.TokenValidationParameters = new TokenValidationParameters
        //         {
        //             ValidateIssuerSigningKey = true,
        //             ValidateIssuer = true,
        //             ValidateAudience = false, // Set to true if needed
        //             ValidIssuer = openIdConnectSettings.Authority,
        //             IssuerSigningKeys = JwkHelper.ConvertJwksToSecurityKeys(openIdConnectSettings.Key)
        //         };
        //     });
        //
        // // Configure Authorization Policies
        // builder.Services.AddAuthorization(options =>
        //     options.AddPolicy("admin",
        //         policy => policy.RequireClaim("sub", "1"))
        // );

        builder.Services.Configure<RazorPagesOptions>(options =>
            options.Conventions.AuthorizeFolder("/Admin", "admin"));

        // Register Dependencies (DI)
        builder.Services.AddTransient<Identity_api.Pages.Portal.ClientRepository>();
        builder.Services.AddTransient<ClientRepository>();
        builder.Services.AddTransient<IdentityScopeRepository>();
        builder.Services.AddTransient<ApiScopeRepository>();

        // Configure Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "X-API-Key",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    new List<string>()
                }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });

        // Register HTTP Clients
        builder.Services.AddHttpClient<RestHttpClientHelper>();

        // Register Application Services (DI)
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IRoleService, RoleService>();

        // Configure model state
        builder.Services.Configure<ApiBehaviorOptions>(options
            => options.SuppressModelStateInvalidFilter = true);

        // Build and return the app
        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Configure the HTTP request pipeline
        app.UseSerilogRequestLogging(); // Logs requests early

        // Custome Middleware
        app.UseMiddleware<ResponseHandlerMiddleware>();

        // app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting(); // Enables endpoint routing

        app.UseIdentityServer(); // IdentityServer should be before authentication
        app.UseAuthentication(); // Ensures requests have valid authentication tokens
        app.UseAuthorization(); // Applies authorization policies

        app.UseSwagger(); // Swagger should come after authentication & authorization
        app.UseSwaggerUI();

        app.MapControllers(); // Maps API controllers
        app.MapRazorPages().RequireAuthorization(); // Protects Razor Pages

        return app;
    }
}