using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductosMVVM.Models.Dataclasses;
using ProductosMVVM.Models.Repositories;
using ProductosMVVM.Models.RestApi;
using ProductosMVVM.Models.Services;

namespace ProductosMVVM.ViewModels
{
    partial class HomeViewModel : ObservableObject
    {
        private readonly IAPIRest<Categoria> servicesC;
        private readonly IAPIRest<Producto> servicesP;
        [ObservableProperty]
        public ObservableCollection<Producto> _ListaProductos = new();

        [ObservableProperty]
        public ObservableCollection<Categoria> _ListaCategorias;

        [ObservableProperty]
        public Categoria _CategoriaSeleccionada = null;

        public HomeViewModel(IAPIRest<Categoria> servicesC, IAPIRest<Producto> servicesP) 
        {
            this.servicesC = servicesC;
            this.servicesP = servicesP;
            Sinchronice();
        }

        private async void Sinchronice()
        {
            var aDevolver = await servicesC.GetAll();

            ListaCategorias = new ObservableCollection<Categoria>(aDevolver);

        }

        private async void DevolverFiltrados() 
        
        {
            var prods = await servicesP.GetAll();
            ListaProductos = new ObservableCollection<Producto>(prods.FindAll(prod => prod.IdCategoria == CategoriaSeleccionada.Id));
        }

        partial  void OnCategoriaSeleccionadaChanged(Categoria value)
        {
            if (CategoriaSeleccionada != null)
            {
                CategoriaSeleccionada = value;
                ListaProductos.Clear();
                DevolverFiltrados();
            }
        }
    }
}
