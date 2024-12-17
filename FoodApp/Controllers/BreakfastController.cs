using FoodApp.Contracts.Breakfast;
using Microsoft.AspNetCore.Mvc;
using FoodApp.Models;
using FoodApp.Services.Breakfasts;
using ErrorOr;
using FoodApp.ServiceErrors;

namespace FoodApp.Controllers;

public class BreakfastController(IBreakfastService breakfastService) : ApiController {
    private readonly IBreakfastService _breakfastService = breakfastService;

    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request) {

        ErrorOr<Breakfast> requestToBreakfastResult = Breakfast.Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Savory,
            request.Sweet
        );

        if (requestToBreakfastResult.IsError) {
            return Problem(requestToBreakfastResult.Errors);
        }

        var breakfast = requestToBreakfastResult.Value;
        ErrorOr<Created> createdBreakfastResult = _breakfastService.Createbreakfast(breakfast);

        return createdBreakfastResult.Match(
            created => CreatedAtGetBreakfast(breakfast),
            Problem
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id) {
        Console.WriteLine(id);
        ErrorOr<Breakfast> getBreakfastResult = _breakfastService.GetBreakfast(id);

        return getBreakfastResult.Match(
            breakfast => Ok(MapBreakfastResponse(breakfast)),
            Problem
        );

        // if (getBreakfastResult.IsError && getBreakfastResult.FirstError == Errors.Breakfast.NotFound) {
        //     return NotFound();
        // }

        // var breakfast = getBreakfastResult.Value;
        // Breakfastresponse response = MapBreakfastResponse(breakfast);
        // return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request) {
        ErrorOr<Breakfast> requestTobreakfastresult = Breakfast.Create(
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            request.Savory,
            request.Sweet,
            id
        );

        if (requestTobreakfastresult.IsError) {
            return Problem(requestTobreakfastresult.Errors);
        }

        var breakfast = requestTobreakfastresult.Value;

        ErrorOr<UpsertedBreakfast> upsertedBreakfastResult = _breakfastService.UpsertBreakfast(breakfast);

        return upsertedBreakfastResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetBreakfast(breakfast) : NoContent(),
            Problem
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id) {
        ErrorOr<Deleted> deleteBreakfastResult = _breakfastService.DeleteBreakfast(id);
        return deleteBreakfastResult.Match(
            deleted => NoContent(),
            Problem
        );
    }

    private static Breakfastresponse MapBreakfastResponse(Breakfast breakfast) {
        return new Breakfastresponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDate,
            breakfast.Savory,
            breakfast.Sweet
        );
    }

    private CreatedAtActionResult CreatedAtGetBreakfast(Breakfast breakfast) {
        return CreatedAtAction(
            actionName: nameof(GetBreakfast),
            routeValues: new { id = breakfast.Id},
            value: MapBreakfastResponse(breakfast)
        );
    }
}

// 30:50