using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CookieCore.ViewModels;

public partial class BuildingViewModel : ObservableObject
{
    private readonly Building _building;
    private readonly GameViewModel _gameViewModel;

    public BuildingViewModel(GameViewModel gameViewModel, Building building)
    {
        _gameViewModel = gameViewModel;
        _building = building;
    }


    public string Identifier => _building.Identifier;
    public int Amount => _building.Amount;
    public double BasePrice => _building.BasePrice;


    [RelayCommand]
    private void Buy()
    {
        if (_gameViewModel.Cookies >= BasePrice)
        {
            _gameViewModel.Cookies -= BasePrice;
            _building.Amount += 1;
            OnPropertyChanged(nameof(Amount));
        }
    }
}