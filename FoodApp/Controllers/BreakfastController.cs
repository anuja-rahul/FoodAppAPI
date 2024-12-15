using FoodApp.Contracts.Breakfast;
using Microsoft.AspNetCore.Mvc;
using FoodApp.Models;
using FoodApp.Services.Breakfasts;

namespace FoodApp.Controllers;

[ApiController]
[Route("breakfasts/")]
public class BreakfastController(IBreakfastService breakfastService) : ControllerBase {
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
        Breakfast breakfast = _breakfastService.Getbreakfast(id);
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
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request) {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id) {
        return Ok(id);
    }
}

// 30:50