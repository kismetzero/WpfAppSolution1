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

namespace WpfAppProject1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private readonly Random _random = new();

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point mouse = e.GetPosition(RootCanvas);
            MousePosLabel.Content = $"x:{mouse.X:F2} y:{mouse.Y:F2}";

            double SafeDistance = 20;

            double left = Canvas.GetLeft(ShyButton);
            double top = Canvas.GetTop(ShyButton);
            double width = ShyButton.ActualWidth;
            double height = ShyButton.ActualHeight;

            Rect buttonRect = new Rect(left, top, width, height);

            Rect buttonOffsetRect = new Rect(
                left - SafeDistance,
                top - SafeDistance,
                width + SafeDistance*2,
                height + SafeDistance * 2);

            if (buttonOffsetRect.Contains(mouse) && !buttonRect.Contains(mouse))
            {
                double maxX = RootCanvas.ActualWidth - width;
                double maxY = RootCanvas.ActualHeight - height;
                if (mouse.X < left)
                {
                    double newLeft = mouse.X + SafeDistance;
                    if (newLeft > maxX) { newLeft = _random.NextDouble() * maxX; }
                    Canvas.SetLeft(ShyButton, newLeft);
                }
                if (mouse.X > left + width)
                {
                    double newLeft = mouse.X - (width + SafeDistance);
                    if (newLeft < 0) { newLeft = _random.NextDouble() * maxX; }
                    Canvas.SetLeft(ShyButton, newLeft);
                }
                if (mouse.Y < top)
                {
                    double newTop = mouse.Y + SafeDistance;
                    if (newTop > maxY) { newTop = _random.NextDouble() * maxY; }
                    Canvas.SetTop(ShyButton, newTop);
                }
                if (mouse.Y > top + height)
                {
                    double newTop = mouse.Y - (height + SafeDistance);
                    if (newTop < 0) { newTop = _random.NextDouble() * maxY; }
                    Canvas.SetTop(ShyButton, newTop);
                }
            }
        }

        private void ShyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You Win!");
        }
    }
}