﻿using Microsoft.Extensions.DependencyInjection;
using ProductosMVVM.Models.Dataclasses;
using ProductosMVVM.Models.Repositories;
using ProductosMVVM.ViewModels;
using ProductosMVVM.Views;
using System.Configuration;
using System.Data;
using System.Windows;
using ProductosMVVM.Data;
using Microsoft.EntityFrameworkCore;
using ProductosMVVM.Models.Services;
using ProductosMVVM.Models.RestApi;

namespace ProductosMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ServiceCollection services = new();
            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<IAPIRest<Producto>, APIProd>();
            services.AddTransient<IAPIRest<Categoria>, APICat>();
            services.AddScoped<IRepository<Producto>, Rproductos>();
            services.AddScoped<IRepository<Categoria>, Rcategoria>();
            services.AddScoped<IServices<Producto>, ProductoServicios>();
            services.AddScoped<IServices<Categoria>, CategoriaServicios>();
            services.AddScoped<SettinsService>();
            services.AddScoped<GraphicsService>();
                
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=localhost,1433;Database=TuBaseDeDatos;User Id=sa;Password=Interfaces-2425;TrustServerCertificate=true;"));
            var serviceProvider = services.BuildServiceProvider();
            // Solo para cargar datos dummy, quitar en aplicación en producción.
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();
                if (dbContext.Categories.Count<Categoria>() == 0)
                {
                    dbContext.Categories.Add(new Categoria { Nombre = "Cosas" });
                    dbContext.Categories.Add(new Categoria { Nombre = "Más cosas" });
                    dbContext.Items.Add(new Producto { Nombre = "Cosa 1", Descripcion = "Descripción de la cosa", IdCategoria = 1, Imagen = "https://bcw-media.s3.ap-northeast-1.amazonaws.com/text_to_image_v6_poster_01_f038887d26.jpg" });
                    dbContext.Items.Add(new Producto { Nombre = "Cosa 2", Descripcion = "Descripción de la cosa", IdCategoria = 2, Imagen = "https://bcw-media.s3.ap-northeast-1.amazonaws.com/text_to_image_v6_poster_04_9952550906.jpg" });
                    dbContext.Items.Add(new Producto { Nombre = "Cosa 3", Descripcion = "Descripción de la cosa", IdCategoria = 1, Imagen = "https://via.placeholder.com/150/0000FF/808080?text=Producto+3" });
                    dbContext.Items.Add(new Producto { Nombre = "Cosa 4", Descripcion = "Descripción de la cosa", IdCategoria = 1, Imagen = "https://via.placeholder.com/150/0000FF/808080?text=Producto+4" });
                    dbContext.Items.Add(new Producto { Nombre = "Cosa 5", Descripcion = "Descripción de la cosa", IdCategoria = 2, Imagen = "https://via.placeholder.com/150/0000FF/808080?text=Producto+5" });
                }
                dbContext.SaveChanges();
            }
            //

            var view = serviceProvider.GetService<MainWindow>();
            view.DataContext = serviceProvider.GetService<MainViewModel>();

            view.Show();
        }
    }
}
