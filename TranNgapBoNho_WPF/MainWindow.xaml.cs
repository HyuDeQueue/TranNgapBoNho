using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace TranNgapBoNho_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;
        private Random _random;

        private Color[] _colors =
        {
            (Color)ColorConverter.ConvertFromString("#F0A8D0"),
            (Color)ColorConverter.ConvertFromString("#F7B5CA"),
            (Color)ColorConverter.ConvertFromString("#FFC6C6"),
            (Color)ColorConverter.ConvertFromString("#FFEBD4")
        };

        public MainWindow()
        {
            InitializeComponent();
            _random = new Random();
        }

        private void ClickMeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_timer == null)
            {
                _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromMilliseconds(20); 
                _timer.Tick += OpenNotifWindow;
                _timer.Start();
            }
        }

        private void OpenNotifWindow(object sender, EventArgs e)
        {
            NotifWindow notifWindow = new NotifWindow();

            Color randomColor = _colors[_random.Next(_colors.Length)];
            notifWindow.Background = new SolidColorBrush(randomColor);

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double x = _random.Next(0, (int)(screenWidth - notifWindow.Width));
            double y = _random.Next(0, (int)(screenHeight - notifWindow.Height));

            notifWindow.Left = x;
            notifWindow.Top = y;
            notifWindow.Show();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
