using BlazorComponentBus;
using BrewUp.Web.Modules.Pubs.Extensions.Abstracts;
using BrewUp.Web.Modules.Pubs.Extensions.Dtos;
using BrewUp.Web.Modules.Pubs.Extensions.Messages;
using BrewUp.Web.Shared.Enums;
using BrewUp.Web.Shared.Messages;
using Microsoft.AspNetCore.Components;

namespace BrewUp.Web.Modules.Pubs;

public class PubsBase : ComponentBase, IDisposable
{
	[Inject] private NavigationManager NavigationManager { get; set; } = default!;
	[Inject] private ComponentBus Bus { get; set; } = default!;
	[Inject] private IPubService PubService { get; set; } = default!;
	[Inject] private IBeerService BeerService { get; set; } = default!;

	protected IEnumerable<PubJson> Pubs { get; set; } = Enumerable.Empty<PubJson>();
	protected IEnumerable<BeerJson> Beers { get; set; } = Enumerable.Empty<BeerJson>();

	protected SalesOrderJson SalesOrder { get; set; } = new();
	protected PubJson CurrentPub { get; set; } = new();

	protected string Message { get; set; } = string.Empty;

	protected bool HideGrid { get; set; }
	protected bool HideDetails { get; set; } = true;

	protected bool IsLoading { get; set; } = true;

	protected override async Task OnInitializedAsync()
	{
		Bus.Subscribe<ToolbarElementClicked>(ToolbarEventHandler);
		Bus.Subscribe<SalesOrderDetailsSubmitted>(SaveSalesOrderCommandHandler);
		Bus.Subscribe<BrewUpEvent>(PubSelectedHandler);

		await LoadPubsAsync();
		await LoadBeersAsync();

		await base.OnInitializedAsync();
	}

	private async Task LoadPubsAsync()
	{
		IsLoading = true;
		Pubs = await PubService.GetPubsAsync();
		IsLoading = false;

		HideGrid = false;
		HideDetails = true;

		StateHasChanged();
	}

	private async Task LoadBeersAsync()
	{
		Beers = await BeerService.GetBeersAsync();
	}

	private void PubSelectedHandler(MessageArgs args)
	{
		var @event = args.GetMessage<BrewUpEvent>();

		CurrentPub = Pubs.FirstOrDefault(p => p.PubId.Equals(new Guid(@event.Body)))!;
	}

	private void ToolbarEventHandler(MessageArgs args)
	{
		var @event = args.GetMessage<ToolbarElementClicked>();

		if (!@event.ModuleName.Equals(ModuleNames.Pubs))
			return;

		if (@event.ToolbarElement.Equals(ToolbarElement.Add))
		{
			SalesOrder = new SalesOrderJson
			{
				SalesOrderId = Guid.NewGuid().ToString(),
				SalesOrderNumber = string.Empty,
				OrderDate = DateTime.UtcNow,
				TotalAmount = 0
			};

			HideGrid = true;
			HideDetails = false;
		}

		if (@event.ToolbarElement.Equals(ToolbarElement.Edit))
		{
			if (string.IsNullOrEmpty(SalesOrder.SalesOrderId) || SalesOrder.SalesOrderId.Equals(Guid.Empty.ToString()))
				return;

			HideGrid = true;
			HideDetails = false;
		}

		if (@event.ToolbarElement.Equals(ToolbarElement.Back))
		{
			Message = string.Empty;
			HideGrid = false;
			HideDetails = true;
		}

		if (@event.ToolbarElement.Equals(ToolbarElement.Close))
			NavigationManager.NavigateTo("/");

		StateHasChanged();
	}

	private void SaveSalesOrderCommandHandler(MessageArgs args)
	{
		var @event = args.GetMessage<SalesOrderDetailsSubmitted>();
		SalesOrder = @event.SalesOrder;

		if (string.IsNullOrEmpty(SalesOrder.SalesOrderNumber))
		{
			Message = "Order Number is Mandatory!";
		}
		else
		{
			Message = string.Empty;

			HideGrid = false;
			HideDetails = true;
		}

		PubService.SendSalesOrderAsync(SalesOrder);

		StateHasChanged();
	}

	#region Dispose
	public void Dispose(bool disposing)
	{
		if (disposing)
		{
		}
	}
	public void Dispose()
	{
		this.Dispose(true);
		GC.SuppressFinalize(this);
	}

	~PubsBase()
	{
		Dispose(false);
	}
	#endregion
}