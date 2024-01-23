namespace AuctionService.DTOs;
public class UpdateAuctionDto
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int? Year { get; set; } //optional
    public string Color { get; set; }
    public int? Mileage { get; set; } //optional
}
