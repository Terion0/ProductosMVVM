using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductosMVVM.Models.Dataclasses;
using ProductosMVVM.Models.Repositories;
using ProductosMVVM.Models.Services;

namespace ProductosMVVM.ViewModels
{
    partial class HomeViewModel(IServices<Categoria> servicesC, IServices<Producto> servicesP) : ObservableObject
    {
   
        [ObservableProperty]
        public ObservableCollection<Producto> _ListaProductos = new();

        [ObservableProperty]
        public ObservableCollection<Categoria> _ListaCategorias = new(servicesC.GetAll());

        [ObservableProperty]
        public Categoria _CategoriaSeleccionada = null;

      

        partial void OnCategoriaSeleccionadaChanged(Categoria value)
        {
            if (CategoriaSeleccionada != null)
            {
                ListaProductos.Clear();
                ListaProductos = new ObservableCollection<Producto>(servicesP.GetAll().FindAll(x => x.IdCategoria == value.Id));
            }
        }
    }
}
