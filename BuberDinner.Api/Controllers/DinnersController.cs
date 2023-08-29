using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("[controller]")]
public class DinnersController : ApiController
{
    [HttpGet]
    public IActionResult ListDinners()
    {
        // You can check `HttpContext.User.Identity.IsAuthenticated` to see if the user is authenticated
        return Ok(Array.Empty<string>());
    }
}