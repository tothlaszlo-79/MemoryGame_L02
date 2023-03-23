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
using System.Windows.Threading;

namespace MemoryGame_L02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _BackgroundName = "background.JPG";
        string[] _ImageName = {"grabowski.jpg",
            "kukori.jpg","kuldonc.jpg","vili.jpg" };
        BitmapImage _biBackground;
        BitmapImage[] _biImages = new BitmapImage[8];
        Image[] _imImage;
        Random rnd = new Random();
        private DispatcherTimer _dt;

        public MainWindow()
        {
            InitializeComponent();
            _imImage = new Image[] {
                im10, im11, im12, im13,
                im20,im21,im22, im23
            };
            LoadImages();
            ShowImages();
            _dt = new DispatcherTimer
            {
                Interval = new TimeSpan(0,0,0,0,3000),
                IsEnabled = false
            };
            _dt.Tick += _dt_Tick;
            _dt.Start();    

        }

        private void ShowImages()
        {
            for (int i = 0; i < 8; i++)
            {
                _imImage[i].Source = _biImages[i];
            }
        }

        private void LoadImages()
        {
            try
            {
                _biBackground = new BitmapImage(
                    new Uri(
                        @"Images/" +_BackgroundName,
                        UriKind.Relative
                    ));

                for (int i = 0; i < 4; i++)
                {
                    _biImages[i] = new BitmapImage(
                        new Uri(@"Images/" + _ImageName[i],
                        UriKind.Relative
                        ));
                    _biImages[i + 4] = _biImages[i];
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Képek nem találhatóak!",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                
            }
        }

        private void _dt_Tick(object? sender, EventArgs e)
        {
            ShowBackground();
            _dt.Stop();
        }

        private void ShowBackground()
        {
            for (int i = 0; i < 8; i++)
            {
                _imImage[i].Source = _biBackground;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }

        private void Mix_Click(object sender, RoutedEventArgs e)
        {
            ShowImages();
        }

        private void Guess_Click(object sender, RoutedEventArgs e)
        {
            MintaAblak mintaAblak = new MintaAblak();
            mintaAblak.Show();
            this.Close();
        }
    }
}
