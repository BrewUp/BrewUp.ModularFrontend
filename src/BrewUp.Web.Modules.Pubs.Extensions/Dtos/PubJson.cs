namespace BrewUp.Web.Modules.Pubs.Extensions.Dtos;

public class PubJson
{
    public Guid PubId { get; set; } = Guid.Empty;
    public string PubName { get; set; } = string.Empty;
}