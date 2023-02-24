using System.Net.Http.Json;
using CozyCornerCafe.Shared;
using Microsoft.AspNetCore.Components;

namespace CozyCornerCafe.Client.Pages;

public partial class WorkdayMenu : ComponentBase
{
	private List<ProductDto> AllProducts = new();
	protected override async Task OnInitializedAsync()
	{
		AllProducts = await _PublicClient.Client.GetFromJsonAsync<List<ProductDto>>("Product/All");
	}
}