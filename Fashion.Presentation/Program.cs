using Fashion.Infrastructure;
using Fashion.Application;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// .AddJsonOptions(options =>
//     {
//         // Configure System.Text.Json options if needed
//         // options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; // Example: CamelCase property names
//         // options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); // Example: to handle Enum as strings
//     });
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// app.MapControllerRoute(
//     name: "admin",
//     pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
