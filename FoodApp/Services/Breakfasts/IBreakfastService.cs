using ErrorOr;
using FoodApp.Models;

namespace FoodApp.Services.Breakfasts;

public interface IBreakfastService {
    ErrorOr<Created> Createbreakfast(Breakfast breakfast);
    ErrorOr<Breakfast> GetBreakfast(Guid id);
    ErrorOr<UpsertedBreakfast> UpsertBreakfast(Breakfast breakfast);
    ErrorOr<Deleted> DeleteBreakfast(Guid id);
}