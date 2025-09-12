using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FashionContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("FashionContext")
        ?? throw new InvalidOperationException("Connection string 'FashionContext' not found.")
    )
);


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Products/Index");
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=products}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
