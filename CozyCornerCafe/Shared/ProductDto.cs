namespace CozyCornerCafe.Shared;

public class ProductDto
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public double Price { get; set; } = 0f;
	public bool IsWeekend { get; set; } = false;
	public string Category { get; set; } = string.Empty;
}