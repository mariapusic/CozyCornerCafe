using CozyCornerCafe.Server.Data.Models;
using CozyCornerCafe.Shared;
using Microsoft.EntityFrameworkCore;

namespace CozyCornerCafe.Server.Data;

public class ProductsRepository
{
	private readonly ProductDbContext _context;

	public ProductsRepository(ProductDbContext context)
	{
		_context = context;
	}

	public async Task<List<ProductDto>> GetAllProducts()
	{
		List<Product> list = await _context.Products.ToListAsync();
		return list.Select(p =>
			new ProductDto
			{
				Id = p.Id,
				Name = p.Name,
				Price = p.Price,
				Category = p.Category,
				IsWeekend = p.IsWeekend
			}).ToList();
	}

	public async Task AddProduct(ProductDto product)
	{
		await _context.Products.AddAsync(new Product
		{
			Name = product.Name,
			Price = product.Price,
			IsWeekend = product.IsWeekend,
			Category = product.Category
		});
		await _context.SaveChangesAsync();
	}

	public async Task UpdateProduct(ProductDto product)
	{
		_context.Products.Update(new Product
		{
			Id = product.Id,
			Name = product.Name,
			Category = product.Category,
			IsWeekend = product.IsWeekend,
			Price = product.Price
		});
		 await _context.SaveChangesAsync();
	}

	public async Task RemoveProduct(int id)
	{
		_context.Products.Remove(new Product
		{
			Id = id
		});
		await _context.SaveChangesAsync();
	}
}