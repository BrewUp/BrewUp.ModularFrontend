using BrewUp.Web.Modules.Production.Events;
using BrewUp.Web.Modules.Pubs.Extensions.Dtos;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BrewUp.Web.Modules.Pubs.Components;

public class PubsGridBase : ComponentBase, IDisposable
{
    [Inject] private BlazorComponentBus.ComponentBus Bus { get; set; } = default!;

    [Parameter] public IEnumerable<PubJson> Pubs { get; set; } = Enumerable.Empty<PubJson>();

    private int _selectedRowNumber = -1;
    protected MudTable<PubJson> MudTable = new();

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }

    protected Task RowClickEvent(TableRowClickEventArgs<PubJson> tableRowClickEventArgs)
    {
        return Bus.Publish(new BrewUpEvent($"Pub selected {tableRowClickEventArgs.Item.PubName}", string.Empty));
    }

    protected string SelectedRowClassFunc(PubJson element, int rowNumber)
    {
        if (_selectedRowNumber == rowNumber)
        {
            _selectedRowNumber = -1;
            return string.Empty;
        }

        if (MudTable.SelectedItem == null || !MudTable.SelectedItem.Equals(element))
            return string.Empty;

        _selectedRowNumber = rowNumber;

        return "selected";
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

    ~PubsGridBase()
    {
        Dispose(false);
    }
    #endregion
}