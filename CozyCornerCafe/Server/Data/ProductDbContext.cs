using CozyCornerCafe.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CozyCornerCafe.Server.Data;

public class ProductDbContext : DbContext
{
	public DbSet<Product> Products { get; set; }

	public ProductDbContext(DbContextOptions options) : base(options)
	{

	}
}