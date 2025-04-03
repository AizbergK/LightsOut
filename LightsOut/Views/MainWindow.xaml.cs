using System.Security.Cryptography.X509Certificates;
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

namespace LightsOut;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public static MainWindow? Instance { get; private set; }
    public static LightsOut.Models.User? programUser { get; private set; }
    public MainWindow()
    {
        InitializeComponent();
        System.IO.Directory.CreateDirectory("users");
        Instance = this;
        programUser = new LightsOut.Models.User();
        Instance.ChangeWindow(new Uri("/Views/Sign_in.xaml", UriKind.Relative));
        Instance.ResizeMode = ResizeMode.NoResize;
    }
    public void ChangeWindow(System.Uri WindowName)
    {
        AppWindow.NavigationService.Navigate(WindowName);
    }
}