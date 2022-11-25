using Microsoft.AspNetCore.Mvc;
using webapi;

namespace webapi_net.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HelloWorldController: ControllerBase
{
    IHelloWorldService helloWorldService;

    // TareasContext dbcontext;
    public HelloWorldController(IHelloWorldService helloWorld)
    {
        helloWorldService = helloWorld;
    }

[HttpGet]
    public IActionResult Get ()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }
}