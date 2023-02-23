using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CookieCore.ViewModels.Messages;

namespace CookieCore.ViewModels;

public partial class GameViewModel : ObservableObject
{
    public GameViewModel(QuantityPickerViewModel quantityPickerViewModel, Game game)
    {
        QuantityPickerViewModel = quantityPickerViewModel;
        Game = game;
        BuildingViewModels = new BuildingViewModel[Game.Buildings.Length];
        for (var i = 0; i < Game.Buildings.Length; i++)
            BuildingViewModels[i] = new BuildingViewModel(this, Game.Buildings[i]);
    }

    public BuildingViewModel[] BuildingViewModels { get; }
    internal Game Game { get; }
    internal QuantityPickerViewModel QuantityPickerViewModel { get; }


    public double Cookies
    {
        get => Game.Cookies;
        internal set
        {
            Game.Cookies = value;
            WeakReferenceMessenger.Default.Send(new CookiesChangedMessage(Cookies));
            OnPropertyChanged();
        }
    }

    public double CookiesPerSecond => Game.Buildings.Sum(x => x.BaseCookiesPerSecond * x.Amount);

    [RelayCommand]
    private void ClickCookie()
    {
        Cookies++;
    }

    internal void Tick(double deltaSeconds)
    {
        Cookies += CookiesPerSecond * deltaSeconds;

        OnPropertyChanged(nameof(CookiesPerSecond));
    }
}