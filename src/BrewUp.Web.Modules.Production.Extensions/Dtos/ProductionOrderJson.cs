namespace BrewUp.Web.Modules.Production.Extensions.Dtos;

public class ProductionOrderJson
{
	public Guid ProductionOrderId { get; set; } = Guid.Empty;
	public string ProductionOrderNumber { get; set; } = string.Empty;
	public DateTime OrderData { get; set; } = DateTime.MinValue;
	public string Status { get; set; } = string.Empty;

	public IEnumerable<ProductionOrderRowJson> Rows { get; set; } = Enumerable.Empty<ProductionOrderRowJson>();
}