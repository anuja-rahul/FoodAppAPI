using FoodApp.Models;

namespace FoodApp.Services.Breakfasts;

public interface IBreakfastService {
    void Createbreakfast(Breakfast breakfast);
    void DeleteBreakfast(Guid id);
    Breakfast Getbreakfast(Guid id);
    void UpsertBreakfast(Breakfast breakfast);
}