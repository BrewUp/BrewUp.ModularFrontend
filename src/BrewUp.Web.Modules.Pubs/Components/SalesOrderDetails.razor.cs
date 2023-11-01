using BlazorComponentBus;
using BrewUp.Web.Modules.Pubs.Extensions.Dtos;
using BrewUp.Web.Modules.Pubs.Extensions.Messages;
using BrewUp.Web.Shared.Enums;
using BrewUp.Web.Shared.Messages;
using Microsoft.AspNetCore.Components;

namespace BrewUp.Web.Modules.Pubs.Components;

public class SalesOrderDetailsBase : ComponentBase, IAsyncDisposable
{
	[Parameter] public SalesOrderJson SalesOrder { get; set; } = new();
	[Parameter] public IEnumerable<BeerJson> Beers { get; set; } = Enumerable.Empty<BeerJson>();
	[Parameter] public IEnumerable<PubJson> Pubs { get; set; } = Enumerable.Empty<PubJson>();
	[Parameter] public PubJson SelectedPub { get; set; } = new();

	protected PubJson CurrentPub { get; set; } = new();

	[Inject] private ComponentBus Bus { get; set; } = default!;

	protected override Task OnInitializedAsync()
	{
		Bus.Subscribe<ToolbarElementClicked>(ToolbarEventHandler);

		return base.OnInitializedAsync();
	}

	protected override Task OnParametersSetAsync()
	{
		CurrentPub = SelectedPub;

		SalesOrder.SalesOrderNumber =
			$"{DateTime.UtcNow.Year:0000}{DateTime.UtcNow.Month:00}{DateTime.UtcNow.Day:00}-{DateTime.UtcNow.Hour:00}{DateTime.UtcNow.Minute:00}";
		SalesOrder.PubId = CurrentPub.PubId.ToString();
		SalesOrder.PubName = CurrentPub.PubName;

		var orderRows = Beers.Select(beer => new SalesOrderRowJson
		{
			BeerId = beer.BeerId,
			BeerName = beer.BeerName,
			Quantity = new Quantity
			{
				Value = 100,
				UnitOfMeasure = "Lt"
			},
			Price = new Price
			{
				Value = 5,
				Currency = "EUR"
			}
		})
			.ToList();
		SalesOrder.Rows = orderRows;

		return base.OnParametersSetAsync();
	}

	private void ToolbarEventHandler(MessageArgs args)
	{
		var @event = args.GetMessage<ToolbarElementClicked>();

		if (!@event.ModuleName.Equals(ModuleNames.Pubs))
			return;

		if (@event.ToolbarElement.Equals(ToolbarElement.ClearAll))
		{
			SalesOrder = new SalesOrderJson
			{
				SalesOrderId = Guid.NewGuid().ToString(),
				SalesOrderNumber = $"{DateTime.UtcNow.Year:0000}{DateTime.UtcNow.Month:00}{DateTime.UtcNow.Day:00}-{DateTime.UtcNow.Hour:00}{DateTime.UtcNow.Minute:00}",
				OrderDate = DateTime.UtcNow,
				TotalAmount = 0
			};

			StateHasChanged();
			return;
		}

		if (!@event.ToolbarElement.Equals(ToolbarElement.Save))
			return;

		SalesOrder.PubId = CurrentPub.PubId.ToString();
		SalesOrder.PubName = CurrentPub.PubName;

		Bus.Publish(new SalesOrderDetailsSubmitted(SalesOrder));
	}

	#region Dispose
	public async ValueTask DisposeAsync()
	{
		await DisposeAsyncInternal();
		GC.SuppressFinalize(this);
	}

	protected virtual async ValueTask DisposeAsyncInternal()
	{
		// Async cleanup mock
		Bus.UnSubscribe<ToolbarElementClicked>(ToolbarEventHandler);
		await Task.Yield();
	}
	#endregion
}