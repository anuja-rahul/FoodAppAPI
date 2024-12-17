using ErrorOr;
using FoodApp.Contracts.Breakfast;
using FoodApp.ServiceErrors;

namespace FoodApp.Models;

public class Breakfast {

    public const int MinNameLength = 5;
    public const int MaxNameLength = 50;
    public const int MinDescriptionLength = 5;
    public const int MaxDescriptionLength = 150;
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime LastModifiedDate { get; }
    public List<string> Savory { get; }
    public List<string> Sweet { get; }

    private Breakfast(Guid id, string name, string description, DateTime startDateTime, DateTime endDateTime, DateTime lastModifiedDate, List<string> savory, List<string> sweet) {
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDate = lastModifiedDate;
        Savory = savory;
        Sweet = sweet;
    }

    public static ErrorOr<Breakfast> Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDatetime,
        List<string> savory,
        List<string> sweet,
        Guid? id = null

    ) {
        // enforce invariants
        List<Error> errors = new();
        if (name.Length is < MinNameLength or > MaxNameLength) {
            errors.Add(Errors.Breakfast.InvalidName);
        }
        if (description.Length is < MinDescriptionLength or > MaxDescriptionLength) {
            errors.Add(Errors.Breakfast.InvalidDescription);
        }

        if (errors.Count > 0) {
            return errors;
        }
        return new Breakfast(
            id  ?? Guid.NewGuid(),
            name,
            description,
            startDateTime,
            endDatetime,
            DateTime.UtcNow,
            savory,
            sweet
        );

    }

    public static ErrorOr<Breakfast> From(CreateBreakfastRequest request) {
        return Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Savory,
            request.Sweet
        );
    }

    public static ErrorOr<Breakfast> From(Guid id, UpsertBreakfastRequest request) {
        return Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Savory,
            request.Sweet,
            id
        );
    }

}