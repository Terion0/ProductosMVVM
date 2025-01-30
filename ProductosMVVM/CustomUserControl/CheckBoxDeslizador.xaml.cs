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
    /// Lógica de interacción para CheckBoxDeslizador.xaml
    /// </summary>
    public partial class CheckBoxDeslizador : UserControl
    {

        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(CheckBoxDeslizador), new PropertyMetadata(false));

        public static readonly DependencyProperty BackgroundColorSlideProperty =
              DependencyProperty.Register("BackgroundColorSlide", typeof(Brush), typeof(CheckBoxDeslizador), new PropertyMetadata(Brushes.Transparent));

      
        public static readonly DependencyProperty BolaColorProperty =
            DependencyProperty.Register("BolaColor", typeof(Brush), typeof(CheckBoxDeslizador), new PropertyMetadata(Brushes.Transparent));


        public Brush BackgroundColorSlide
        {
            get { return (Brush)GetValue(BackgroundColorSlideProperty); }
            set { SetValue(BackgroundColorSlideProperty, value); }
        }

        public Brush BolaColor
        {
            get { return (Brush)GetValue(BolaColorProperty); }
            set { SetValue(BolaColorProperty, value); }
        }
        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public CheckBoxDeslizador()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.IsChecked = true;
        }
    }
}
