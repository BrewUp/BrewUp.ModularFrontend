using BlazorComponentBus;
using BrewUp.Web.Modules.Production.Events;
using BrewUp.Web.Modules.Production.Extensions.Abstracts;
using BrewUp.Web.Modules.Production.Extensions.Dtos;
using BrewUp.Web.Shared.Configuration;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace BrewUp.Web.Modules.Production;

public class ProductionBase : ComponentBase, IAsyncDisposable
{
	[Inject] private ComponentBus Bus { get; set; } = default!;
	[Inject] private IProductionService ProductionService { get; set; } = default!;
	[Inject] private AppConfiguration Configuration { get; set; } = new();

	protected string Message { get; set; } = string.Empty;
	protected IEnumerable<ProductionOrderJson> ProductionOrders { get; set; } = Enumerable.Empty<ProductionOrderJson>();

	protected ProductionOrderJson CurrentOrder = default!;

	protected override async Task OnInitializedAsync()
	{
		Bus.Subscribe<BrewUpEvent>(MessageAddedHandler);

		await LoadProductionOrderAsync();

		await base.OnInitializedAsync();
	}

	private async Task LoadProductionOrderAsync()
	{
		ProductionOrders = await ProductionService.GetProductionOrdersAsync();
	}

	private void MessageAddedHandler(MessageArgs args)
	{
		var action = args.GetMessage<BrewUpEvent>().Message;
		switch (action)
		{
			case "OrderSelected":
				CurrentOrder = JsonSerializer.Deserialize<ProductionOrderJson>(args.GetMessage<BrewUpEvent>().Body)!;
				Message = $"Order Selected {CurrentOrder.ProductionOrderNumber}";
				break;

			case "CompleteOrder":
				if (string.IsNullOrEmpty(CurrentOrder.ProductionOrderNumber))
				{
					Message = "Select an Order Please!";
					return;
				}

				ProductionService.CloseProductionOrderAsync(CurrentOrder.ProductionOrderId.ToString());
				break;
		}

		StateHasChanged();
	}

	#region Dispose
	public async ValueTask DisposeAsync()
	{

	}

	private static void Dispose(bool disposing)
	{
		if (disposing)
		{
		}
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	~ProductionBase()
	{
		Dispose(false);
	}
	#endregion
}