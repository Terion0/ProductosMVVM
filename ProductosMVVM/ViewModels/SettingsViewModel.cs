using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductosMVVM.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ProductosMVVM.Models.Services;
namespace ProductosMVVM.ViewModels
{
     partial class SettingsViewModel(SettinsService Service) : ObservableObject
    {
        [ObservableProperty]
        public CultureInfo _culturaActiva=Thread.CurrentThread.CurrentCulture;

        [ObservableProperty]
        public ObservableCollection<CultureInfo> _Culturas= new(Service.GetCulturas());

      
        partial void OnCulturaActivaChanged(CultureInfo value)
        {  
                Service.GetCulture(value);
                MessageBox.Show($"Cultura cambiada a: {value.DisplayName}");
                MainWindow nueva = new MainWindow();
                nueva.DataContext = Application.Current.MainWindow.DataContext;
                Application.Current.MainWindow.Close();
                Application.Current.MainWindow = nueva;
                nueva.Show();          
            }
        }
    }
    
