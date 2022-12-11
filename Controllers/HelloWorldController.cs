using Microsoft.AspNetCore.Mvc;
using webapi;

namespace webapi_net.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HelloWorldController: ControllerBase
{
    IHelloWorldService helloWorldService;

    private readonly ILogger<HelloWorldController> _logger;

    // TareasContext dbcontext;
    public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger)
    {
        _logger = logger;
        helloWorldService = helloWorld;
    }

[HttpGet]
    public IActionResult Get ()
    {
        _logger.LogDebug("Logging desde del método Get()");
        return Ok(helloWorldService.GetHelloWorld());
    }
}