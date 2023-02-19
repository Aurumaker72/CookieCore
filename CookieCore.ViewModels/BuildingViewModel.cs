using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CookieCore.ViewModels;

public partial class BuildingViewModel : ObservableObject
{
    private readonly GameViewModel _gameViewModel;
    private readonly Building _building;
    
    public BuildingViewModel(GameViewModel gameViewModel, Building building)
    {
        _gameViewModel = gameViewModel;
        _building = building;
    }


    public string Identifier => _building.Identifier;
    public int Amount => _building.Amount;
    public double Price => _building.Price;


    [RelayCommand]
    private void Buy()
    {
        if (_gameViewModel.Cookies >= Price)
        {
            _gameViewModel.Cookies -= Price;
            _building.Amount += 1;
            OnPropertyChanged(nameof(Amount));
        }
    }
}