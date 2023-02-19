using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookieCore.Services;
using Newtonsoft.Json;

namespace CookieCore.ViewModels;

public partial class MainViewModel : ObservableObject
{
	private static TimeSpan Tickrate = TimeSpan.FromMilliseconds(1000 / 60);

	private string _serialized;
    
    private GameViewModel _gameViewModel;
    public GameViewModel GameViewModel => _gameViewModel;

    public MainViewModel(ITimersService timersService)
    {
	    timersService.Create(Tickrate, () =>
	    {
		    GameViewModel?.Tick(Tickrate.TotalMilliseconds / 1000);
	    });
	    
	    // load default save
	    _serialized = JsonConvert.SerializeObject(Game.Default);
	    LoadCommand.Execute(null);
    }
    
    [RelayCommand]
    private void Save()
    {
	    _serialized = JsonConvert.SerializeObject(_gameViewModel.Game);
    }

    [RelayCommand]
    private void Load()
    {
	    _gameViewModel = new(JsonConvert.DeserializeObject<Game>(_serialized));
	    OnPropertyChanged(nameof(GameViewModel));
    }
}