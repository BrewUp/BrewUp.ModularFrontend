﻿using BrewUp.Web.Modules.Production.Events;
using Microsoft.AspNetCore.Components;

namespace BrewUp.Web.Modules.Production.Components;

public class ProductionToolbarBase : ComponentBase, IDisposable
{
	[Inject] private BlazorComponentBus.ComponentBus Bus { get; set; } = default!;

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
	}

	protected Task OnCompleteOrderBeer()
	{
		return Bus.Publish(new BrewUpEvent("CompleteOrder", null));
	}

	#region Dispose
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

	~ProductionToolbarBase()
	{
		Dispose(false);
	}
	#endregion
}