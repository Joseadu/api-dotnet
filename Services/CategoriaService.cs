using webapi.Models;

namespace webapi.Services;
public class CategoriaService: ICategoriaService
{
    TareasContext context;

    public CategoriaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }

    public async Task Save(Categoria categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }
    
    public async Task Update(Guid id, Categoria categoria)
    {
        var categorioaActual = context.Categorias.Find(id);

        if(categorioaActual != null)
        {
            categorioaActual.Nombre = categoria.Nombre;
            categorioaActual.Descripcion = categoria.Descripcion;
            categorioaActual.Peso = categoria.Peso;

            await context.SaveChangesAsync();
        }
        
        context.Add(categoria);
        await context.SaveChangesAsync();
    }
    
    public async Task Delete(Guid id)
    {
        var categorioaActual = context.Categorias.Find(id);

        if(categorioaActual != null)
        {
            await context.SaveChangesAsync();
            context.Remove(categorioaActual);
        }
    }
}

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task Save(Categoria categoria);
    Task Update(Guid id, Categoria categoria);
    Task Delete(Guid id);
}