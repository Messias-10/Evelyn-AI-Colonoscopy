using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectodeTituloFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded; // Inicia el video cuando la ventana se cargue
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            VideoPlayer.Play(); // Inicia la reproducción manualmente
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void VideoPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            VideoPlayer.Position = TimeSpan.Zero; // Reinicia el video al inicio
            VideoPlayer.Play(); // Vuelve a reproducirlo
        }

        private void IniciarSesion()
        {
            // Código para iniciar sesión
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            IniciarSesion();
        }
    }
}