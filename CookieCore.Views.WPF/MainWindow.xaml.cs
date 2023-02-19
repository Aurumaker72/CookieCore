using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Threading;
using CookieCore.Services;
using CookieCore.ViewModels;

namespace CookieCore.Views.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ITimersService
    {
        public MainViewModel MainViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MainViewModel = new(this);
            DataContext = this;
        }


        public ITimer Create(TimeSpan interval, Action callback)
        {
            // TODO: implement this properly
            var timer = new DispatcherTimer(interval, DispatcherPriority.Normal, (sender, args) => callback(), Dispatcher);
            return null;
        }
    }
}