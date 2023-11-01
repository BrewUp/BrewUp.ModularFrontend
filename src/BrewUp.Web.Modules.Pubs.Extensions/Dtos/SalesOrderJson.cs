namespace BrewUp.Web.Modules.Pubs.Extensions.Dtos;

public class SalesOrderJson
{
	public string SalesOrderId { get; set; } = string.Empty;
	public string SalesOrderNumber { get; set; } = string.Empty;
	public DateTime? OrderDate { get; set; } = DateTime.Now;

	public string PubId { get; set; } = string.Empty;
	public string PubName { get; set; } = string.Empty;

	public double TotalAmount { get; set; } = 0;
	public IEnumerable<SalesOrderRowJson> Rows { get; set; } = Enumerable.Empty<SalesOrderRowJson>();
}