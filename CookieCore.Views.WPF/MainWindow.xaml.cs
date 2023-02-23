using System;
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

    private void BuyButton_Click(object sender, RoutedEventArgs e)
    {
        if (((FrameworkElement)sender).DataContext is BuildingViewModel buildingViewModel)
        {
            if (!buildingViewModel.Buy()) MessageBox.Show("implement buy/sell error sfx for wpf frontend :)");
        }
        else
        {
            throw new Exception(); // uh
        }
    }
}