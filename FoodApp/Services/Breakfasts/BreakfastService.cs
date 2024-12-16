using FoodApp.Models;

namespace FoodApp.Services.Breakfasts;

public class BreakfastService : IBreakfastService
{
    private static readonly Dictionary<Guid, Breakfast> _breakfasts = [];
    public void Createbreakfast(Breakfast breakfast)
    {
        Console.WriteLine(_breakfasts);
        _breakfasts.Add(breakfast.Id, breakfast);
    }

    public void DeleteBreakfast(Guid id)
    {
        _breakfasts.Remove(id);
    }

    public Breakfast Getbreakfast(Guid id)
    {
        return _breakfasts[id];
    }

    public void UpsertBreakfast(Breakfast breakfast)
    {
        _breakfasts[breakfast.Id] = breakfast;
    }
}