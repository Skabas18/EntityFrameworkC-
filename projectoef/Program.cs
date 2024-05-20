using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;
using proyectoef.Models;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("CnTareasDb"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet(
    "/dbconexion",
    ([FromServices] TareasContext dbContext) =>
    {
        dbContext.Database.EnsureCreated();
        return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
    }
);

app.MapGet(
    "/api/tareas",
    ([FromServices] TareasContext dbContext) =>
    {
        return Results.Ok(
            dbContext.Tareas.Include(p => p.Categoria)
        // .Where(p => p.PrioridadTarea == proyectoef.Models.Prioridad.Baja)
        );
    }
);

app.MapPost(
    "/api/tareas",
    async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
    {
        tarea.TareaId = Guid.NewGuid();
        tarea.FechaCreacion = DateTime.Now;
        await dbContext.AddAsync(tarea);
        // await dbContext.Tareas.AddAsync(tarea);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
);

app.MapPut(
    "/api/tareas/{id}",
    async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
    {
        var tareaActual = dbContext.Tareas.Find(id);
        if (tareaActual != null)
        {
            tareaActual.CategoriaId = tarea.CategoriaId;
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;
            tareaActual.Descripcion = tarea.Descripcion;
            await dbContext.SaveChangesAsync();
            return Results.Ok();
        }
        else
        {
            return Results.NotFound();
        }
    }
);
app.Run();
