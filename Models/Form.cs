namespace FormAPI.Models;

public class Form {
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    
    public string? Secret { get; set; }
}