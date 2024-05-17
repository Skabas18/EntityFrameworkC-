using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proyectoef.Models;

namespace proyectoef
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria() {CategoriaId= Guid.Parse("ee24c066-d0bb-4a47-8bdd-ff3b6651ccea"), Nombre= "Actividades pendientes", peso= 20});
            categoriasInit.Add(new Categoria() {CategoriaId= Guid.Parse("ee24c066-d0bb-4a47-8bdd-ff3b6651cc02"), Nombre= "Actividades personales", peso= 50});

            modelBuilder.Entity<Categoria>(categoria =>{
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p =>p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p =>p.Descripcion);
                categoria.Property(p=>p.peso);

                categoria.HasData(categoriasInit);
            });

            List<Tarea> tareasInit = new List<Tarea>();
            tareasInit.Add(new Tarea() {TareaId= Guid.Parse("ee24c066-d0bb-4a47-8bdd-ff3b66512cea"),CategoriaId= Guid.Parse("ee24c066-d0bb-4a47-8bdd-ff3b6651ccea"), PrioridadTarea = Prioridad.Media, Titulo= "Revisar pago de servicios publicos", FechaCreacion = DateTime.Now});
            tareasInit.Add(new Tarea() {TareaId= Guid.Parse("ee24c066-d0bb-4a47-8bdd-ff3b66512c11"),CategoriaId= Guid.Parse("ee24c066-d0bb-4a47-8bdd-ff3b6651cc02"), PrioridadTarea = Prioridad.Baja, Titulo= "Terminar de ver pelicula en Netflix", FechaCreacion = DateTime.Now});

            modelBuilder.Entity<Tarea>(tarea =>{
                tarea.ToTable("Tarea");
                tarea.HasKey(p=> p.TareaId);
                tarea.HasOne(p => p.Categoria).WithMany( p => p.Tareas).HasForeignKey(p => p.CategoriaId);
                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p => p.Descripcion);
                tarea.Property(p => p.PrioridadTarea);
                tarea.Property(p => p.FechaCreacion).HasDefaultValue(DateTime.Now);
                tarea.Ignore(p => p.Resumen);
                tarea.HasData(tareasInit);
            });
        }
    }
}
