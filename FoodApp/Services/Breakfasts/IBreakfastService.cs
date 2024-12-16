using ErrorOr;
using FoodApp.Models;

namespace FoodApp.Services.Breakfasts;

public interface IBreakfastService {
    void Createbreakfast(Breakfast breakfast);
    void DeleteBreakfast(Guid id);
    ErrorOr<Breakfast> GetBreakfast(Guid id);
    void UpsertBreakfast(Breakfast breakfast);
}