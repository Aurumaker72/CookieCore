using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CookieCore.ViewModels;

public partial class GameViewModel : ObservableObject
{
    public GameViewModel(Game game)
    {
        Game = game;
        BuildingViewModels = new BuildingViewModel[Game.Buildings.Length];
        for (var i = 0; i < Game.Buildings.Length; i++)
            BuildingViewModels[i] = new BuildingViewModel(this, Game.Buildings[i]);
    }

    public BuildingViewModel[] BuildingViewModels { get; }

    internal Game Game { get; }


    public double Cookies
    {
        get => Game.Cookies;
        internal set
        {
            Game.Cookies = value;
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