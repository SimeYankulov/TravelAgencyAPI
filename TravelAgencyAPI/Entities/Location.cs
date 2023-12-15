namespace TravelAgencyAPI.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Number { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;

    }
}
