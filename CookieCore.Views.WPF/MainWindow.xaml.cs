using System.Windows;
using CookieCore.ViewModels;
using CookieCore.Views.WPF.Services;

namespace CookieCore.Views.WPF;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainViewModel = new MainViewModel(new TimersService(Dispatcher), new FilesService(), 60);
        DataContext = this;
    }

    public MainViewModel MainViewModel { get; set; }
}