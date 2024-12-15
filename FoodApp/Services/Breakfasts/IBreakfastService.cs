using FoodApp.Models;

namespace FoodApp.Services.Breakfasts;

public interface IBreakfastService {
    void Createbreakfast(Breakfast breakfast);
    Breakfast Getbreakfast(Guid id);
}