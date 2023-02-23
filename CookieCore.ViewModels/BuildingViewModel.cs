using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CookieCore.ViewModels.Messages;

namespace CookieCore.ViewModels;

public class BuildingViewModel : ObservableObject, IRecipient<BuyAmountChangedMessage>, IRecipient<CookiesChangedMessage>
{
    private readonly Building _building;
    private readonly GameViewModel _gameViewModel;

    public BuildingViewModel(GameViewModel gameViewModel, Building building)
    {
        _gameViewModel = gameViewModel;
        _building = building;
        WeakReferenceMessenger.Default.RegisterAll(this);
    }


    public string Identifier => _building.Identifier;

    public int DisplayAmount => _gameViewModel.QuantityPickerViewModel.Amount;
    public double DisplayPrice => GetPriceForAmount(_building.Amount) + GetPriceForAmount(_gameViewModel.QuantityPickerViewModel.Amount);
    
    public bool CanAfford
    {
        get
        {
            if (_gameViewModel.QuantityPickerViewModel.IsBuying)
            {
                return _gameViewModel.Cookies >= GetPriceForAmount(_gameViewModel.QuantityPickerViewModel.Amount);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    } 
        
    void IRecipient<BuyAmountChangedMessage>.Receive(BuyAmountChangedMessage message)
    {
        OnPropertyChanged(nameof(DisplayPrice));
        OnPropertyChanged(nameof(DisplayAmount));
        OnPropertyChanged(nameof(CanAfford));
    }
    void IRecipient<CookiesChangedMessage>.Receive(CookiesChangedMessage message)
    {
        OnPropertyChanged(nameof(CanAfford));
    }

    private double GetPriceForAmount(double amount)
    {
        return _building.BasePrice * Math.Pow(1.15, Math.Max(0, amount));
    }

    /// <summary>
    ///     Buys or sells this building, depending on the <see cref="QuantityPickerViewModel" />'s state
    /// </summary>
    /// <returns>Whether the buy/sell operation succeeded</returns>
    public bool Buy()
    {
        if (!CanAfford)
        {
            return false;
        }
        
        if (_gameViewModel.QuantityPickerViewModel.IsBuying)
        {
            var price = GetPriceForAmount(_gameViewModel.QuantityPickerViewModel.Amount);
            if (_gameViewModel.Cookies >= price)
            {
                _building.Amount += _gameViewModel.QuantityPickerViewModel.Amount;
                _gameViewModel.Cookies -= price;
                OnPropertyChanged(nameof(DisplayAmount));
                OnPropertyChanged(nameof(DisplayPrice));
                OnPropertyChanged(nameof(CanAfford));
                return true;
            }

            return false;
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}