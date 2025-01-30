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
    /// Lógica de interacción para SearchBar.xaml
    /// </summary>
    public partial class SearchBar : UserControl
    {

        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(string), typeof(SearchBar));

        public SearchBar()
        {
            InitializeComponent();
        }
        public string Image
        {
            get => (string)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }
    }
}
