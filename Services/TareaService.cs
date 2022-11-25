using webapi.Models;

namespace webapi.Services;

public class TareasService: ITareasService
{
    TareasContext context;

    public TareasService(TareasContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    public async Task Save(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea)
    {
        var tareaaActual = context.Tareas.Find(id);

        if(tareaaActual != null)
        {
            tareaaActual.Titulo = tarea.Titulo;
            tareaaActual.Descripcion = tarea.Descripcion;
            tareaaActual.PrioridadTarea = tarea.PrioridadTarea;
            tareaaActual.FechaCreacion = tarea.FechaCreacion;

            await context.SaveChangesAsync();
        }
        
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var tareaActual = context.Categorias.Find(id);

        if(tareaActual != null)
        {
            await context.SaveChangesAsync();
            context.Remove(tareaActual);
        }
    }
}

public interface ITareasService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea Tarea);

    Task Update(Guid id, Tarea Tarea);

    Task Delete(Guid id);
}