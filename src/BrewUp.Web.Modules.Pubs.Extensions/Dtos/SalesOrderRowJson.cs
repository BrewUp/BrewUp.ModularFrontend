namespace BrewUp.Web.Modules.Pubs.Extensions.Dtos;

public class SalesOrderRowJson
{
	public string BeerId { get; set; } = string.Empty;
	public string BeerName { get; set; } = string.Empty;
	public Quantity Quantity { get; set; } = new();
	public Price Price { get; set; } = new();
}