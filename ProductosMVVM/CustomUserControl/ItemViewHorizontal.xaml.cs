using ProductosMVVM.Models.Dataclasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProductosMVVM.CustomUserControl
{
    /// <summary>
    /// Lógica de interacción para ItemViewHorizontal.xaml
    /// </summary>
    public partial class ItemViewHorizontal : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Titulo", typeof(string), typeof(ItemViewHorizontal));
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Imagen", typeof(string), typeof(ItemViewHorizontal));
        public static readonly DependencyProperty IsPulsadoProperty = DependencyProperty.Register("IsPulsado", typeof(bool), typeof(ItemViewHorizontal), new PropertyMetadata(false));
        public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(ItemViewHorizontal), new PropertyMetadata(Brushes.Transparent));
        public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(ItemViewHorizontal), new PropertyMetadata(Brushes.Transparent));
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(ItemViewHorizontal), new PropertyMetadata(null));
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(ItemViewHorizontal), new PropertyMetadata(null));

        public event EventHandler Click;

        public string Titulo
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string Imagen
        {
            get => (string)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }
        public bool IsPulsado
        {
            get => (bool)GetValue(IsPulsadoProperty);
            set => SetValue(IsPulsadoProperty, value);
        }

        public Brush Background
        {
            get => (Brush)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }
        public Brush BorderBrush
        {
            get => (Brush)GetValue(BorderBrushProperty);
            set => SetValue(BorderBrushProperty, value);
        }
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }
        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

       

        public ItemViewHorizontal()
        {
            InitializeComponent();
        }
    }
}
