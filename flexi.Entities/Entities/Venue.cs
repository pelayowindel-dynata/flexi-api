namespace flexi.Entities
{
    public record Venue
    {
        public int VenueId { get; init; }
        public string VenueName { get; init; } = string.Empty;
        public int VenueCapacity { get; init; }
    }
}