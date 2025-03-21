namespace flexi.Common.DTO;

public record CreateVenueDto
{
  public string VenueName { get; init; } = string.Empty;
  public int VenueCapacity { get; init; }
}