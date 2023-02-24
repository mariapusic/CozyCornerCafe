namespace CozyCornerCafe.Server.Data.Models;

public class Product
{
	public int Id { get; set; } = 0;
	public string Name { get; set; } = string.Empty;
	public double Price { get; set; } = 0f;
	public bool IsWeekend { get; set; } = false;
	public string Category { get; set; } = string.Empty;
}