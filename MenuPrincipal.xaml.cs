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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProyectodeTituloFinal
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {

        private string[] phrases = {
            "Transformando la detección del cáncer de colon con IA",
            "La IA que ve lo que el ojo humano podría pasar por alto.",
            "Precisión, velocidad y confianza en cada diagnóstico",
            "Tu salud en manos de la mejor tecnología",
            "Tecnología que salva vidas, un pólipo a la vez"
        };

        private int currentPhraseIndex = 0;
        private DispatcherTimer timer;

        public MenuPrincipal()
        {
            InitializeComponent();
            StartAnimation();
        }

        private void StartAnimation()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(8); // Cambia cada 3 segundos
            timer.Tick += (s, e) => AnimateTextChange();
            timer.Start();
        }

        private void AnimateTextChange()
        {
            // Animación de salida (desvanece y mueve el texto)
            DoubleAnimation fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.5));
            DoubleAnimation moveOut = new DoubleAnimation(0, -50, TimeSpan.FromSeconds(0.5));

            fadeOut.Completed += (s, e) =>
            {
                // Cambiar el texto después de la animación de salida
                currentPhraseIndex = (currentPhraseIndex + 1) % phrases.Length;
                PhraseText.Text = phrases[currentPhraseIndex];

                // Animación de entrada (mueve y muestra el texto)
                DoubleAnimation fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.6));
                DoubleAnimation moveIn = new DoubleAnimation(50, 0, TimeSpan.FromSeconds(0.6));

                PhraseText.BeginAnimation(UIElement.OpacityProperty, fadeIn);
                TextTransform.BeginAnimation(TranslateTransform.XProperty, moveIn);
            };

            PhraseText.BeginAnimation(UIElement.OpacityProperty, fadeOut);
            TextTransform.BeginAnimation(TranslateTransform.XProperty, moveOut);
        }
    }
}
