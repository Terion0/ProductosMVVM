using CommunityToolkit.Mvvm.ComponentModel;
using ProductosMVVM.Models.Dataclasses;
using ProductosMVVM.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using System.Collections.ObjectModel;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using CommunityToolkit.Mvvm.Input;

namespace ProductosMVVM.ViewModels
{
    internal partial class GraphicsViewModel : ObservableObject
    {
        private readonly GraphicsService servicesG;

        public GraphicsViewModel(GraphicsService services)
        {
            servicesG = services;
            LoadCharts();
        }

        [ObservableProperty]
        private ISeries[] _pieChart;

        [ObservableProperty]
        private ISeries[] _series;

        [ObservableProperty]
        private Axis[] _xAxes;

        [RelayCommand]
        public async Task ActCharts()
        {
            await LoadCharts();
        }

        private async Task LoadCharts()
        {
            PieChart = await servicesG.DevolverPieSeries();
            Series = await servicesG.DevolverValores();
            XAxes = await servicesG.DevolverEjeX();
        }
    }
}

    
