using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductosMVVM.Models.Dataclasses;
using ProductosMVVM.Models.Repositories;
using ProductosMVVM.Models.Services;
namespace ProductosMVVM.ViewModels
{
    partial class ViewTwoModel(IServices<Categoria> servicios) : ObservableObject
    {

        [ObservableProperty]
        public Categoria _CategoriaSeleccionado;
        [ObservableProperty]
        public ObservableCollection<Categoria> _ListaCategorias = new(servicios.GetAll());


        [ObservableProperty]
        public string _NombreCat = "";
        [ObservableProperty]
        public string _IdCat = "";




        partial void OnCategoriaSeleccionadoChanged(Categoria value)
        {
            if (value != null)
                MostrarInfo();
        }

        [RelayCommand]
        private void EliminarCategoria()
        {
            if (CategoriaSeleccionado != null)
            {
                servicios.Remove(CategoriaSeleccionado);
                limpiar();
            }
        }
        [RelayCommand]
        private void ModificarCategoria()
        {
            if (CategoriaSeleccionado != null)
            {
          
                CategoriaSeleccionado.Nombre = NombreCat;          
                servicios.Update(CategoriaSeleccionado);
                limpiar();
             
              
            }
            else { MessageBox.Show("Categoria no editada"); }
        }
    

        [RelayCommand]
        private void AñadirCategoria()
        {
            Categoria c = new Categoria();
            c.Nombre=NombreCat;
            servicios.Add(c);   
            CategoriaSeleccionado = null;
            limpiar();       
        }
        public void limpiar()
        {
           string white = "";
            NombreCat = white;
            IdCat = white;
            ListaCategorias.Clear();
            ListaCategorias = new ObservableCollection<Categoria>(servicios.GetAll());
        }
        public void MostrarInfo()
        {
          IdCat = CategoriaSeleccionado.Id.ToString();
          NombreCat = CategoriaSeleccionado.Nombre;
          
        }
    }
    }

