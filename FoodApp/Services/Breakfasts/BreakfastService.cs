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

    public Breakfast Getbreakfast(Guid id)
    {
        return _breakfasts[id];
    }
}