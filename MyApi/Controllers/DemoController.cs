using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DemoController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            message = "Hello from DevOps Demo!",
            timestamp = DateTime.Now,
            server = Environment.MachineName
        });
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(new
        {
            id = id,
            message = $"You requested item {id}",
            timestamp = DateTime.Now
        });
    }
}
