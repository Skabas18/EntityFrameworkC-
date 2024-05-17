using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("CnTareasDb"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!"); 

app.MapGet("/dbconexion", ([FromServices] TareasContext dbContext) => {
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: "+ dbContext.Database.IsInMemory());
});

app.MapGet("/api/tareas", ([FromServices] TareasContext dbContext) => {
    return Results.Ok(dbContext.Tareas.Include(p =>p.Categoria).Where(p => p.PrioridadTarea == proyectoef.Models.Prioridad.Baja));
});

app.Run();
