using CozyCornerCafe.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace CozyCornerCafe.Client.Pages;

public partial class Admin : ComponentBase
{
	ProductDto addProduct = new();
	List<ProductDto>? allProducts = new();
	private bool editMode = false;
	private async Task Submit()
	{
		if (editMode)
		{
			await _Client.PutAsJsonAsync("Product", addProduct);
			addProduct = new();
			editMode = false;
		}
		else
		{
		await _Client.PostAsJsonAsync("Product", addProduct);
			addProduct = new();
		}
	}

	protected override async Task OnInitializedAsync()
	{
		allProducts = await _Client.GetFromJsonAsync<List<ProductDto>>("Product/All") ?? new();
	}

	private void SelectProduct(int id)
	{
		addProduct = allProducts.First(p => p.Id == id);
		editMode = true;
	}

	private async Task RemoveProduct(int productId)
	{
		await _Client.DeleteAsync($"Product/{productId}");
		addProduct = new();
		editMode = false;
	}
}