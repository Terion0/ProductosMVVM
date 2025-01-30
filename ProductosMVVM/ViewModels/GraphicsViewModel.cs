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
    internal partial class GraphicsViewModel(GraphicsService services) : ObservableObject
    {
        [ObservableProperty]
        public ISeries[] _PieChart = services.DevolverPieSeries();

        [ObservableProperty]
        public ISeries[] _Series = services.DevolverValores();

        [ObservableProperty]
        public Axis[] _XAxes = services.DevolverEjeX();


        [RelayCommand]
        public void ActCharts()
        {
            PieChart = services.DevolverPieSeries();
            Series = services.DevolverValores();
            XAxes = services.DevolverEjeX();
        }

    }
}

    
