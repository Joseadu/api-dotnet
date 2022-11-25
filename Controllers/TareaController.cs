using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[Route("api/[controller]")]
public class TareaController: ControllerBase
{
    ITareasService tareaService;

    public TareaController (ITareasService service)
    {
        tareaService = service;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(tareaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        tareaService.Save(tarea);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(Guid id,[FromBody] Tarea tarea)
    {
        tareaService.Update(id, tarea);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        tareaService.Delete(id);
        return Ok();
    }
}