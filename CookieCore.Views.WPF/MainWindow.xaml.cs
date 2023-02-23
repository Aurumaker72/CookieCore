using System;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Threading;
using CookieCore.Services;
using CookieCore.Services.Abstractions;
using CookieCore.ViewModels;
using CookieCore.Views.WPF.Services;

namespace CookieCore.Views.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel MainViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MainViewModel = new(new TimersService(Dispatcher), new FilesService());
            DataContext = this;
        }
    }
}