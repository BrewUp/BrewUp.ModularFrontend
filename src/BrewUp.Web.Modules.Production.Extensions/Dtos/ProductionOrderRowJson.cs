namespace BrewUp.Web.Modules.Production.Extensions.Dtos;

public class ProductionOrderRowJson
{
	public Guid BeerId { get; set; } = Guid.Empty;
	public string BeerName { get; set; } = string.Empty;
	public Quantity Quantity { get; set; } = new();
}