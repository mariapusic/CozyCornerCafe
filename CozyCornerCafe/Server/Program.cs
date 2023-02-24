using CozyCornerCafe.Server.Data;
using CozyCornerCafe.Shared;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductDbContext>(options =>
{
	options.UseSqlite("FileName=database.db");
});

builder.Services.AddScoped<ProductsRepository>();
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapGet("/Product/All", async (ProductsRepository repo) =>
{
	return await repo.GetAllProducts();
});
app.MapPost("/Product", async (ProductsRepository repo, ProductDto product) =>
{
	await repo.AddProduct(product);
	return Results.Ok();
});
app.MapPut("/Product", async (ProductsRepository repo, ProductDto product) =>
{
	try
	{
		await repo.UpdateProduct(product);
		 return Results.Ok();
	}
	catch (Exception e)
	{
		Console.WriteLine(e);
		return Results.BadRequest();
	}
});
app.MapDelete("/Product/{id}", async (ProductsRepository repo, int id) =>
{
	await repo.RemoveProduct(id);
	return Results.Ok();
});

app.MapFallbackToFile("index.html");

app.Run();
