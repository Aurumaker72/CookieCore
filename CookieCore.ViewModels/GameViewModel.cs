using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CookieCore.ViewModels;

public partial class GameViewModel : ObservableObject
{
	private readonly Game _game;
    private readonly BuildingViewModel[] _buildingViewModels;

    public BuildingViewModel[] BuildingViewModels => _buildingViewModels;
    internal Game Game => _game;
    
    public GameViewModel(Game game)
    {
        _game = game;
        _buildingViewModels = new BuildingViewModel[_game.Buildings.Length];
        for (int i = 0; i < _game.Buildings.Length; i++)
        {
	        _buildingViewModels[i] = new BuildingViewModel(this, _game.Buildings[i]);
        }
    }


    public double Cookies
    {
	    get => _game.Cookies;
	    internal set
	    {
		    _game.Cookies = value;
		    OnPropertyChanged();
	    }
    }

	public double CookiesPerSecond => _game.Buildings.Sum(x => x.CookiesPerSecond * x.Amount);

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