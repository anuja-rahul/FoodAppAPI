using Microsoft.AspNetCore.Mvc;

namespace FoodApp.Controllers;

public class ErrorController : ControllerBase {
    [Route("/error")]
    public IActionResult Error() {
        return Problem();
    }
}