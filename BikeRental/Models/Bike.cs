namespace BikeRental.Models
{
    public class Bike
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public bool IsAvailable { get; set; }
        public decimal PricePerHour { get; set; }
        public string Status => IsAvailable ? "Available" : "Unavailable";
    }
}
