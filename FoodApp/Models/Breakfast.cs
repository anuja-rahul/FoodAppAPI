namespace FoodApp.Models;

public class Breakfast(
    Guid id,
    string name,
    string description,
    DateTime startDateTime,
    DateTime endDateTime,
    DateTime lastModifiedDate,
    List<string> savory,
    List<string> sweet)
{
    public Guid Id { get; } = id;
    public string Name { get; } = name;
    public string Description { get; } = description;
    public DateTime StartDateTime { get; } = startDateTime;
    public DateTime EndDateTime { get; } = endDateTime;
    public DateTime LastModifiedDate { get; } = lastModifiedDate;
    public List<string> Savory { get; } = savory;
    public List<string> Sweet { get; } = sweet;
}