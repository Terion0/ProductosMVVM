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

namespace ProductosMVVM.CustomUserControl
{
    /// <summary>
    /// Lógica de interacción para CardView.xaml
    /// </summary>
    public partial class CardView : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Titulo",typeof(string),typeof(CardView));

        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Imagen", typeof(string), typeof(CardView));

        public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(CardView), new PropertyMetadata(Brushes.Transparent));

        //Ya lo he pillado
        public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(CardView), new PropertyMetadata(Brushes.Transparent));

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

        public CardView() => InitializeComponent();

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e) =>
        Click?.Invoke(this, EventArgs.Empty);


      
    }
}
