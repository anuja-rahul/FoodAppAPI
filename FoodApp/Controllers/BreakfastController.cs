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

        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );

        _breakfastService.Createbreakfast(breakfast);

        var response = new Breakfastresponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDate,
            breakfast.Savory,
            breakfast.Sweet
        );

        return CreatedAtAction(
            actionName: nameof(GetBreakfast),
            routeValues: new {id = breakfast.Id} ,
            value: response);
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

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request) {
        var breakfast = new Breakfast(
            id,
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );
        _breakfastService.UpsertBreakfast(breakfast);

        // TODO: return 201 if new breakfast is created
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id) {
        _breakfastService.DeleteBreakfast(id);
        return NoContent();
    }
}

// 30:50