namespace flexi.Common.Model
{
    public record CreateVenue
    {
        public string VenueName { get; init; } = string.Empty;
        public int VenueCapacity { get; init; }
    }
}