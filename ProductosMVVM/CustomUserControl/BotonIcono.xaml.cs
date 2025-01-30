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
    /// Lógica de interacción para BotonIcono.xaml
    /// </summary>
    public partial class BotonIcono : UserControl
    {

        //En resumen: Las propiedades que quiera cambiar desde fuera las tengo que poner aquí.

        /*Te lo he copiado de la presentación. Bendito seas, me he tirado 4 días buscando en
        Internet y he acabado hasta las narices de tutoriales de hindúes. :´) */
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(BotonIcono));

        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(string), typeof(BotonIcono));

        //Esto lo deja en estado pulsado, en vez de usar un IsPressed. Ahora tengo que implementar la lógica del radiobutton
        public static readonly DependencyProperty IsPulsadoProperty = DependencyProperty.Register("IsPulsado", typeof(bool), typeof(BotonIcono), new PropertyMetadata(false));
        //El coso del comando. A ver como lo uso.
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(BotonIcono), new PropertyMetadata(null));

      
       

        //PARA CAMBIAR EL COLOR DE FORMA DINÁMICA NECESITO ESTO. Madre mia como no he caído antes.
        public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(BotonIcono), new PropertyMetadata(Brushes.Transparent));

        //Ya lo he pillado
        public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(BotonIcono), new PropertyMetadata(Brushes.Transparent));

        /*Que he aprendido:
        -Todas las características que quiera cambiar desde fuera las tengo que poner aquí.
        -Puedo hacer referencias estáticas o bindear comandos a propiedades.
        -La lógica de los botones la tengo que hacer yo si quiero un comportamiento de determinado tipo
        -
        */
        public event EventHandler Click;
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
        public string Image
        {
            get => (string)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
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

        public BotonIcono() => InitializeComponent();



        /*¿Como hago que este evento haga que el botón se mantenga con color?????
        Propiedad isPressed?  NO, solo se mantiene al pulsar. Al despulsar no pasa nada
        ¿Y si me genero mi propio isPulsado?
        */
        //Gracias StackOverflow. Me has salvado la vida. :´)
        private void OnMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            List<StackPanel> list = new();
            var parent = VisualTreeHelper.GetParent(this);  
                if (parent != null)
                {
                    if (parent is StackPanel panel)
                    {
                       if (panel.Parent is Grid grid)
                    {
                        foreach (var stackpanel in grid.Children)
                        {
                            if (stackpanel is StackPanel paneld)
                            {
                                list.Add(paneld);
                            }
                        }
                    }
                }
                foreach (var panelStack in list)
                {
                    foreach (var buttonIcon in panelStack.Children)
                    {
                        if (buttonIcon is BotonIcono button)
                            button.IsPulsado = button == this;
                    }
                }
            }
                Click?.Invoke(this, EventArgs.Empty);
            }

        }
    }

