
using ProductosMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductosMVVM.Models.Repositories;
using ProductosMVVM.Models.Services;
using ProductosMVVM.Models.Dataclasses;
using Microsoft.Identity.Client;
using SkiaSharp;

namespace ProductosMVVM.ViewModels
{
    partial class MainViewModel(IServices<Producto> serviciosP, IServices<Categoria> serviciosC, SettinsService settins, GraphicsService graphics): ObservableObject
    {


        [ObservableProperty]
        private object _ActiveView;

        public HomeViewModel HomeViewModel;

        public ViewOneModel ViewOneModel { get; } = new ViewOneModel(serviciosC,serviciosP);

        public ViewTwoModel ViewTwoModel { get; } = new ViewTwoModel(serviciosC);

        public SettingsViewModel ViewSettings { get; } = new SettingsViewModel(settins);

        public GraphicsViewModel GraphicsView { get; } = new GraphicsViewModel(graphics);




        [RelayCommand]
        private void ActivateHomeView() => ActiveView = new HomeViewModel(serviciosC, serviciosP);

        [RelayCommand]
        private void ActiveOneView() => ActiveView =  ViewOneModel;

        [RelayCommand]
        private void ActiveTwoView() => ActiveView = ViewTwoModel;

        [RelayCommand]
        private void UnactivateView() => ActiveView = null;

        [RelayCommand]
        private void ActivateSettingsView() => ActiveView = ViewSettings;

        [RelayCommand]
        private void ActivateGraphicsView() => ActiveView = GraphicsView; 




    }
}
    